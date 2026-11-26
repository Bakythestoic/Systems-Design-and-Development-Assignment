using Microsoft.VisualStudio.TestTools.UnitTesting;
using CET_2007_ASSIGNMENT;
using System.Collections.Generic;
using System;

namespace CET_2007_ASSIGNMENT_TESTS
{
    [TestClass]
    public class LoginSecurityTests
    {
        [TestMethod]
        public void DetectMultipleFailedLogins_ThreeFailures_FlagsUser()
        {
            // Arrange
            // Create a list of login attempts with three failed attempts for the same user
            List<LoginAttempt> attempts = new List<LoginAttempt>
            {
                new LoginAttempt
                (
                    "Jordan",
                     "192.168.1.50",
                    new System.DateTime(2026, 11, 8, 9, 0, 0),
                     false
                ),
                 new LoginAttempt
                (
                  "Jordan",
                    "192.168.1.50",
                   new System.DateTime(2026, 11, 8, 9, 2, 0),
                  false
                ),
                  new LoginAttempt
                (
                    "Jordan",
                    "192.168.1.50",
                    new System.DateTime(2026, 11, 8, 9, 4, 0),
                    false
                ),
            };
            // Act
            // Create an instance of the LoginSecurityAnalyzer
            LoginSecurityAnalyzer analyzer = new LoginSecurityAnalyzer();

            // Call the method to detect multiple failed logins
            List<string> result = analyzer.DetectMultipleFailedLogins(attempts);

            // Assert
            // Verify that the user "Jordan" is flagged for multiple failed logins
            CollectionAssert.Contains(result, "Jordan");

        }


        [TestMethod]
        public void DetectMultipleFailedLogins_TwoFailures_DoesNotFlagUser()
        {
            List<LoginAttempt> attempts = new List<LoginAttempt>
            {
                new LoginAttempt
                (
                    "Olivia",
                    "192.168.1.60",
                    new System.DateTime(2026, 11, 8, 10, 0, 0),
                    false
                ),
                 new LoginAttempt(

                     "Olivia",
                    "192.168.1.60",
                    new System.DateTime(2026, 11, 8, 10, 2, 0),
                    false

                 )
            };
            LoginSecurityAnalyzer analyzer = new LoginSecurityAnalyzer();

            List<string> result = analyzer.DetectMultipleFailedLogins(attempts);

            CollectionAssert.DoesNotContain(result, "Olivia");
        }
        [TestMethod]
        public void DetectSuccessfulLoginAfterFailures_ThreeFailuresThenSuccess_FlagsUser()
        {
            List<LoginAttempt> attempts = new List<LoginAttempt>
            {
                new LoginAttempt
                (
                    "Jordan",
                    "192.168.1.50",
                    new System.DateTime(2026, 11, 8, 9, 0, 0),
                    false

                ),new LoginAttempt
                (
                    "Jordan",
                    "192.168.1.50",
                    new System.DateTime(2026, 11, 8, 9, 2, 0),
                    false

                ),new LoginAttempt
                (
                    "Jordan",
                    "192.168.1.50",
                    new System.DateTime(2026, 11, 8, 9, 4, 0),
                    false

                ),new LoginAttempt
                (
                    "Jordan",
                    "192.168.1.50",
                    new System.DateTime(2026, 11, 8, 9, 6, 0),
                    true

                ),


            };

            LoginSecurityAnalyzer analyzer = new LoginSecurityAnalyzer();

            List<string> result = analyzer.DetectSuccessfulLoginAfterFailures(attempts);

            CollectionAssert.Contains(result, "Jordan");
        }
        [TestMethod]

        public void DetectSuccessfulLoginAfterFailures_SucccessBeforeThreeFailures_DoesNotFlagUser()
        {
            List<LoginAttempt> attempts = new List<LoginAttempt>
            {
                   new LoginAttempt
                (
                    "Olivia",
                    "192.168.1.60",
                    new System.DateTime(2026, 11, 8, 9, 0, 0),
                    false
                ),   new LoginAttempt
                (
                    "Olivia",
                    "192.168.1.60",
                    new System.DateTime(2026, 11, 8, 9, 2, 0),
                    true
                ),   new LoginAttempt
                (
                    "Olivia",
                    "192.168.1.60",
                    new System.DateTime(2026, 11, 8, 9, 4, 0),
                    false
                ),   new LoginAttempt
                (
                    "Olivia",
                    "192.168.1.60",
                    new System.DateTime(2026, 11, 8, 9, 6, 0),
                    false
                ),   new LoginAttempt
                (
                    "Olivia",
                    "192.168.1.60",
                    new System.DateTime(2026, 11, 8, 9, 8, 0),
                    false
                ),
            };

            LoginSecurityAnalyzer analyzer = new LoginSecurityAnalyzer();

            List<string> result = analyzer.DetectSuccessfulLoginAfterFailures(attempts);

            CollectionAssert.DoesNotContain(result, "Olivia");
        }


        [TestMethod]
        public void DetectExcessiveIPAttempts_ElevenAttempts_FlagsIP()
        {
            List<LoginAttempt> attempts = new List<LoginAttempt>();
            for (int i = 0; i < 11; i++)
            {
                attempts.Add(new LoginAttempt
                (
                    "Jordan",
                    "192.168.1.80",
                    new System.DateTime(2026, 11, 8, 9, 0, 0).AddMinutes(i),
                    true
                ));
            }
            LoginSecurityAnalyzer analyzer = new LoginSecurityAnalyzer();

            List<string> result = analyzer.DetectExcessiveIPAttempts(attempts);

            CollectionAssert.Contains(result, "192.168.1.80");
        }
        [TestMethod]
        public void DetectExcessiveIPAttempts_TenAttempts_DoesNotFlagIP()
        {
            List<LoginAttempt> attempts = new List<LoginAttempt>();
            for (int i = 0; i < 10; i++)
            {
                attempts.Add(new LoginAttempt
                (
                    "Olivia",
                    "192.168.1.60",
                    new System.DateTime(2026, 11, 8, 9, 0, 0).AddMinutes(i),
                    true
                ));
            }
            LoginSecurityAnalyzer analyzer = new LoginSecurityAnalyzer();

            List<string> result = analyzer.DetectExcessiveIPAttempts(attempts);

            CollectionAssert.DoesNotContain(result, "192.168.1.60");

        }
        [TestMethod]
        public void SearchByUsername_MatchingUsername_ReturnsMatchingAttempts()
        {
            List<LoginAttempt> attempts = new List<LoginAttempt>
            {
                new LoginAttempt("Jordan", "192.168.1.10",DateTime.Now,false),
                new LoginAttempt("Sarah", "192.168.1.11",DateTime.Now,true),
                new LoginAttempt("Jordan", "192.168.1.12",DateTime.Now,true),

            };
            LoginSearchManager searchManager = new CET_2007_ASSIGNMENT.LoginSearchManager();

            List<LoginAttempt> results = searchManager.SearchByUsername(attempts, "Jordan");

            Assert.AreEqual(2, results.Count);
        }
        [TestMethod]
        public void SortByTimestamp_UnsortedattemptsReturnSortedAttempts()
        {
            List<LoginAttempt> attempts = new List<LoginAttempt>
            {
                new LoginAttempt("Jordan","192.168.1.10",new DateTime(2026,5,3),true),
                new LoginAttempt("Sarah","192.168.1.11",new DateTime(2026,5,1),false),
                new LoginAttempt("Bryan","192.168.1.12",new DateTime(2026,5,2),true),

            };
            LoginSortManager sortManager = new LoginSortManager();

            List<LoginAttempt> results = sortManager.SortByTimestamp(attempts);
            Assert.AreEqual(new DateTime(2026, 5, 1), results[0].Timestamp);
            Assert.AreEqual(new DateTime(2026, 5, 2), results[1].Timestamp);
            Assert.AreEqual(new DateTime(2026, 5, 3), results[2].Timestamp);

        }
    }
}



          

    
