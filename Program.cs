using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CET_2007_ASSIGNMENT
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("========Welcome to the Login Security Monitoring System============ ");
              LoginDataManager dataManager = new LoginDataManager();

  List<LoginAttempt> attempts = dataManager.LoadLoginAttempts();

  LoginSecurityAnalyzer analyzer = new LoginSecurityAnalyzer();

  LoginSearchManager searchManager = new LoginSearchManager();

  List<LoginAttempt> searchResults = searchManager.SearchByUsername(attempts,"Jordan");
  Console.WriteLine(Environment.NewLine + "Login attempts found for Jordan:");
  foreach(LoginAttempt attempt in searchResults)
  {
      Console.WriteLine(attempt.Username + ""+attempt.Timestamp+ attempt.IPAddress);
  }

  LoginSortManager sortManager = new LoginSortManager();
  List<LoginAttempt> sortedAttempts = sortManager.SortByTimestamp(attempts);
  Console.WriteLine(Environment.NewLine + "Login attempts sorted from oldest to newest");

  foreach(LoginAttempt attempt in sortedAttempts)
  {
      Console.WriteLine(attempt.Username + " "+attempt.Timestamp  );
      Console.WriteLine(Environment.NewLine);
  }


  List<string> flaggedUsers = analyzer.DetectMultipleFailedLogins(attempts);


  List<string> successfulAfterFailures = analyzer.DetectSuccessfulLoginAfterFailures(attempts);
 
  List<string> excessiveIPAttempts = analyzer.DetectExcessiveIPAttempts(attempts);
  Console.WriteLine(Environment.NewLine + "IP Addresses flagged for excessive login attempts from the same IP address:");

  foreach(string ip in excessiveIPAttempts)
  {
      Console.WriteLine(ip);
  }
  Console.WriteLine("========================================================================================================================");

  Console.WriteLine(Environment.NewLine + "Users flagged for successful login after multiple failed attempts:");

  foreach (string username in successfulAfterFailures)
  {
      Console.WriteLine(username);
  }

  Console.WriteLine("========================================================================================================================");


  Console.WriteLine(Environment.NewLine + "Users flagged for multiple failed login attempts:");
  foreach (var user in flaggedUsers)
  {
      Console.WriteLine(user);
  }

  Console.WriteLine("========================================================================================================================");


  Console.WriteLine(Environment.NewLine + $"Total login attempts loaded: {attempts.Count}");

  Console.WriteLine("========================================================================================================================");

 
 
 

  SecurityAlertFactory factory = new SecurityAlertFactory();

  SecurityAlertPublisher publisher = new SecurityAlertPublisher();

  ConsoleAlertObserver consoleObserver = new ConsoleAlertObserver();
  publisher.Subscribe(consoleObserver);

  FileAlertObserver fileObserver = new FileAlertObserver();
  publisher.Subscribe(fileObserver);


  foreach (string username in flaggedUsers)
  {
      SecurityAlert issue = factory.CreateAlert(AlertType.FailedLogin, "Multiple failed login attempts detected", DateTime.Now, username );
      publisher.Notify(issue);
      Console.WriteLine( Environment.NewLine);
  }

 

  foreach(string username in successfulAfterFailures)
  {
      SecurityAlert issue = factory.CreateAlert(AlertType.SuccessfulLoginAfterFailures, "Successful login datected after multiple failed attempts " , DateTime.Now, username);
      publisher.Notify(issue);

      Console.WriteLine(Environment.NewLine);
  }

  foreach (string ip in excessiveIPAttempts)
  {
      SecurityAlert issue = factory.CreateAlert(AlertType.ExcessiveIP, "Excessive login  attempts detected  from the same Ip Address", DateTime.Now, ip + Environment.NewLine);
      publisher.Notify(issue);
  }


            
        }
    }
}
