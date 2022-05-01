using System;
using System.IO;
using System.Xml;

namespace TestXML
{
    class Program
    {
        static void Main(string[] args)
        {
            const int SENDMSG = 5;
            Console.WriteLine("Test XML assembler");

            XmlDocument xmlAssembler = new XmlDocument();

            XmlDeclaration docDeclaration = xmlAssembler.CreateXmlDeclaration("1.0", "UTF-8", null);
            XmlElement docRoot = xmlAssembler.DocumentElement;
            xmlAssembler.InsertBefore(docDeclaration, docRoot);

            XmlElement docMessages = xmlAssembler.CreateElement("Messages");
            xmlAssembler.AppendChild(docMessages);

            for (int i = 0; i < SENDMSG; i++)
            {
                XmlElement docMessage = xmlAssembler.CreateElement("Message");
                docMessage.SetAttribute("Sender", "tom");
                docMessage.SetAttribute("Receiver", "mas");
                docMessage.SetAttribute("DateTimeSend", DateTime.Parse($"{i + 1}/03/2004 10:{i + 1}:00").ToString());

                XmlElement docText = xmlAssembler.CreateElement("Text");
                XmlText docTextContent = xmlAssembler.CreateTextNode($"{i + 1}) Prova invio messaggio via XML");
                docText.AppendChild(docTextContent);
                docMessage.AppendChild(docText);
                docMessages.AppendChild(docMessage);
            }

            string xmlOutput = xmlAssembler.OuterXml;

            // Writing XML on a file with indentation
            //if (!Directory.Exists("./xml/"))
            //{
            //    Directory.CreateDirectory("./xml/");
            //}
            //xmlAssembler.Save(XmlWriter.Create("./xml/test.xml", new XmlWriterSettings() { Indent = true }));
            // END Writing XML on a file with indentation

            Console.WriteLine(xmlOutput);
            Console.WriteLine("XML Assemblato Correttamente");

            //Console Divider
            for (int i = 0; i < Console.WindowWidth; i++)
                Console.Write('-');
            Console.WriteLine();
            //Console Divider

            Console.WriteLine("Test XML parser");

            XmlDocument xmlReader = new XmlDocument();
            xmlReader.LoadXml(xmlOutput);
            //xmlReader.Load("./xml/test.xml");

            XmlNode xmlElem = xmlReader.DocumentElement.SelectSingleNode("/Messages");
            foreach (XmlNode xmlNode in xmlElem.ChildNodes)
            {
                string msgSender = xmlNode.Attributes["Sender"].InnerText;
                string msgReceiver = xmlNode.Attributes["Receiver"].InnerText;
                DateTime msgDateTimeSend = DateTime.Parse(xmlNode.Attributes["DateTimeSend"].InnerText);
                string msgText = xmlNode.FirstChild.InnerText;
                Console.WriteLine($"\nMessaggio:\n Sender: {msgSender}\n Receiver: {msgReceiver}\n DateTimeSend: {msgDateTimeSend}\n Testo: {msgText}\nFINE MSG");
            }

            Console.ReadKey();
        }
    }
}
