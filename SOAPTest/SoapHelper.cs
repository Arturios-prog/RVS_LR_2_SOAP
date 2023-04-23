using Soap.Shared.Models;
using System.Net;
using System.Xml;
using System.Xml.Serialization;

namespace SOAPTest
{
    public class SoapHelper
    {


        public static Product? CallGetProductDetailsService(int productId)
        {
            string _url = "http://localhost:5299/Service.asmx";
            XmlDocument soapEnvelopeXml = CreateGetProductEnvelope(productId);
            HttpWebRequest webRequest = CreateWebRequest(_url, null);
            InsertSoapEnvelopeIntoWebRequest(soapEnvelopeXml, webRequest);

            // begin async call to web request.
            IAsyncResult asyncResult = webRequest.BeginGetResponse(null, null);

            // suspend this thread until call is complete. You might want to
            // do something usefull here like update your UI.
            asyncResult.AsyncWaitHandle.WaitOne();

            // get the response from the completed web request.
            using (WebResponse webResponse = webRequest.EndGetResponse(asyncResult))
            {
                using (StreamReader rd = new StreamReader(webResponse.GetResponseStream()))
                {
                    var x = rd.ReadToEnd();

                    XmlDocument xmlDoc = new XmlDocument();

                    xmlDoc.LoadXml(x);

                    XmlNamespaceManager nsmgr = new XmlNamespaceManager(xmlDoc.NameTable);

                    while (xmlDoc.DocumentElement.Name == "s:Envelope" || xmlDoc.DocumentElement.Name == "s:Body")
                    {
                        string tempXmlString = xmlDoc.DocumentElement.InnerXml;
                        xmlDoc.LoadXml(tempXmlString);
                    }

                    var xmlt = xmlDoc.DocumentElement.InnerXml;

                    if (string.IsNullOrEmpty(xmlt))
                        return null;

                    using (StringReader sr = new StringReader(xmlDoc.DocumentElement.InnerXml))
                    {
                        XmlRootAttribute xRoot = new XmlRootAttribute();

                        xRoot.ElementName = "GetProductDetailsResult";
                        xRoot.Namespace = "http://tempuri.org/";
                        xRoot.IsNullable = true;

                        XmlSerializer xmlSerializer = new XmlSerializer(typeof(Product), xRoot);

                        var product = (Product)xmlSerializer.Deserialize(sr);

                        return product;
                    }
                }
            }
        }

        private static HttpWebRequest CreateWebRequest(string url, string? action)
        {
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
            webRequest.Headers.Add("SOAPAction", action);
            webRequest.ContentType = "text/xml;charset=\"utf-8\"";
            webRequest.Accept = "text/xml";
            webRequest.Method = "POST";
            return webRequest;
        }

        private static XmlDocument CreateGetProductEnvelope(int productId)
        {
            XmlDocument soapEnvelopeDocument = new XmlDocument();

            var xml =
                $@"<?xml version=""1.0"" encoding=""utf-8""?> 
                    <soap:Envelope xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/""> 
                        <soap:Body> 
                            <GetProductDetails xmlns=""http://tempuri.org/""> 
                                <productId>{productId}</productId> 
                            </GetProductDetails> 
                        </soap:Body> 
                    </soap:Envelope>";

            soapEnvelopeDocument.LoadXml(xml);
            return soapEnvelopeDocument;
        }

        private static void InsertSoapEnvelopeIntoWebRequest(XmlDocument soapEnvelopeXml, HttpWebRequest webRequest)
        {
            using (Stream stream = webRequest.GetRequestStream())
            {
                soapEnvelopeXml.Save(stream);
            }
        }
    }
}
