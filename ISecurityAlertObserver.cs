using CET_2007_ASSIGNMENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CET_2007_ASSIGNMENT
{
    public interface ISecurityAlertObserver
    {
        void Update(SecurityAlert alert);
    }
    public class ConsoleAlertObserver : ISecurityAlertObserver
    {
        public void Update(SecurityAlert alert)
        {
            Console.WriteLine(alert.GetAlertMessage());
        }

    }
    public class FileAlertObserver : ISecurityAlertObserver 
    {
        public void Update(SecurityAlert alert)
        {
            SecurityAlertLogger logger = SecurityAlertLogger.GetInstance();
            logger.LogAlert(alert);
        }
    }
    public class SecurityAlertPublisher 
    {
        private List<ISecurityAlertObserver> observers = new List<ISecurityAlertObserver>();
        
        public void Subscribe(ISecurityAlertObserver observer)
        {
            observers.Add(observer);
        }
        public void Unsubscribe(ISecurityAlertObserver observer)
        {
            observers.Remove(observer);
        }
        
        public void Notify(SecurityAlert alert)
        {
            foreach(ISecurityAlertObserver observer in observers)
            {
                observer.Update(alert);
            }
        }
    }


}
