using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;

namespace CET_2007_ASSIGNMENT
{
    internal class LoginDataManager
    {
           public List<LoginAttempt> LoadLoginAttempts()
   {

       try
       {

           string jsonData = File.ReadAllText("LoginAttempt.json");

           return JsonSerializer.Deserialize<List<LoginAttempt>>(jsonData) ?? new List<LoginAttempt>();


       }
       catch (FileNotFoundException)
       {
           Console.WriteLine("LoginAttempt.json file not found. Returning an empty list.");
           return new List<LoginAttempt>();
       }
       catch (JsonException)
       {
           Console.WriteLine("Error occurred while deserializing JSON data. Returning an empty list.");
           return new List<LoginAttempt>();
       }
   }

       public void SaveLoginAttempts(List<LoginAttempt> attempts)
       {
       try
       {
           string jsonData = JsonSerializer.Serialize(attempts);
           File.WriteAllText("LoginAttempt.json", jsonData);
       }
       catch (UnauthorizedAccessException)
       {
           Console.WriteLine("Sorry, but you do not have permission to write to the file");
       }
       catch (IOException)
       {
           Console.WriteLine("Sorry, but there was a problem writing to the file");
       }
   }
   }
    }
}
