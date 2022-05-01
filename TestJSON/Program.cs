using System;
using System.Collections.Generic;

using Newtonsoft.Json;

namespace TestJSON
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Test JSON assembler");
            Console.WriteLine("For work it needs the newtonsoft plugin");

            List<MessageModel> messages = new List<MessageModel>(new MessageModel[] { 
                new MessageModel("tom", "mas", DateTime.Now, "invio da Tom a Mas"), 
                new MessageModel("mas", "tom", DateTime.Today.AddDays(1), "invio da Mas a Tom nel futuro"),
                new MessageModel("tom", "mas", DateTime.Today.AddDays(-1), "invio da Tom a Mas nel passato"),
                new MessageModel("mas", "tom", DateTime.MinValue, "vecchio invio da Mas a Tom")
            });

            string jsonOutput = JsonConvert.SerializeObject(messages);
            Console.WriteLine(jsonOutput);

            string outJson = "[{\"sender\":\"tom\",\"receiver\":\"mas\",\"dateTimeSend\":\"2022-04-30T12:20:00+02:00\",\"text\":\"invio da Tom a Mas\"}]";
            messages.Clear();
            messages = JsonConvert.DeserializeObject<List<MessageModel>>(jsonOutput);
            Console.WriteLine(messages.Count);

            messages.Clear();
            messages = JsonConvert.DeserializeObject<List<MessageModel>>(outJson);
            Console.WriteLine(messages.Count);
        }
    }
}
