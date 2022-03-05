using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace Business.Concrete
{
    public class SmsManager : ISmsService
    {
        public string Message { get; set; }
        public List<string> ReceipentList { get; set; }
        public string ReceipentListId { get; set; }
        public SmsManager()
        {
        }
        private string api = "http://api.iletimerkezi.com/v1/send-sms";
        private string userName = "5433232164";
        private string userPassword = "Terra2010";

        public IResult SendIndividualMessage(string message, params string[] cellPhone)
        {
            this.Message = message;
            this.ReceipentList = new List<string>();
            for (int i = 0; i < cellPhone.Length; i++)
            {
                this.ReceipentList.Add("+90" + cellPhone[i]);
            }
            var result = SendSms();
            if (result.Success)
            {
                return new SuccessResult(Messages.SmsSended);
            }
            return new ErrorResult(Messages.SmsCouldNotSend);
        }
        private IResult SendSms()
        {
            String xml = "<request>";
            xml += "<authentication>";
            xml += "<username>" + userName + "</username>";
            xml += "<password>" + userPassword + "</password>";
            xml += "</authentication>";
            xml += "<order>";
            xml += "<sender>CCOFTHUKUK</sender>";
            xml += "<sendDateTime></sendDateTime>";
            xml += "<message>";
            xml += "<text>" + this.Message + " #GlobalHerYerde" + "</text>";
            xml += "<receipents>";
            ///this.RECEIPENT_LIST.Add("+905356445438");
            for (int i = 0; i < this.ReceipentList.Count; i++)
            {
                xml += "<number>" + this.ReceipentList[i] + "</number>";
            }
            xml += "</receipents>";
            xml += "</message>";
            xml += "</order>";
            xml += "</request>";

            var res = "";
            byte[] bytes = Encoding.UTF8.GetBytes(xml);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(api);

            request.Method = "POST";
            request.ContentLength = bytes.Length;
            request.ContentType = "text/xml";
            request.Timeout = 300000000;
            using (Stream requestStream = request.GetRequestStream())
            {
                requestStream.Write(bytes, 0, bytes.Length);
            }

            // This sample only checks whether we get an "OK" HTTP status code back.
            // If you must process the XML-based response, you need to read that from
            // the response stream.
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    string message = String.Format(
                    "POST failed. Received HTTP {0}",
                    response.StatusCode);
                    throw new ApplicationException(message);
                }

                Stream responseStream = response.GetResponseStream();
                using (StreamReader rdr = new StreamReader(responseStream))
                {
                    res = rdr.ReadToEnd();
                }
                return new SuccessResult(Messages.SmsSended);
            }
        }




    }
}
