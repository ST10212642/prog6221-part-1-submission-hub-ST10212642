using System;
using System.Media;
using System.Threading;
using System.Drawing;
using Console = Colorful.Console;
using System.Collections.Generic;

namespace CyberSecurityChatbot
{
    class Program
    {
        private const string ASCII_ART = @"
   ____           __                __                  
  / __/__  _____ / /_ _____ ____ _ / /_ ___   _____    
 / /_/ _ \/ ___// __// ___// __ `// __// _ \ / ___/    
/___/\___/\__/ \__/ \__/ /_/ /_/ \__/ \___//_/        
  ___          __      __               __             
 / _ ) __ __  / /____ / /__ ___  ___   / /_ ___   _____
 / _  |/ // / / //___// //_// _ \/ _ \ / __// _ \ / ___/
/____/ \_,_/ /_/     / ,__/ \___/\___/ \__/ \___//_/    
                    /_/                                 
";

        static void Main(string[] args)
        {
            try
            {
                InitializeChatbot();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nCritical error: {ex.Message}", Color.Red);
                Console.WriteLine("Please restart the application.", Color.Yellow);
            }
        }

        static void InitializeChatbot()
        {
            PlayWelcomeSound();
            DisplayWelcomeScreen();
            string userName = GetUserName();
            DisplayMainMenu(userName);
        }

        static void PlayWelcomeSound()
        {
            try
            {
                using (var player = new SoundPlayer("welcome.wav"))
                {
                    player.Play();
                    Thread.Sleep(2000);
                }
            }
            catch
            {
                Console.WriteLine("Audio disabled - proceeding with text interface", Color.Yellow);
            }
        }

        static void DisplayWelcomeScreen()
        {
            Console.Clear();
            Console.WriteAscii("CYBER AWARENESS", Color.Cyan);
            
            string[] asciiLines = ASCII_ART.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
            for (int i = 0; i < asciiLines.Length; i++)
            {
                Console.WriteLine(asciiLines[i], Color.FromArgb(0, 179 + (i * 2), 255 - (i * 2)));
            }
            
            Console.WriteLine(new string('=', 80), Color.DarkCyan);
        }

        static string GetUserName()
        {
            while (true)
            {
                Console.Write("\nHello! Before we begin, what should I call you? ", Color.White);
                string userName = Console.ReadLine()?.Trim();
                
                if (!string.IsNullOrWhiteSpace(userName))
                {
                    Console.WriteLine($"\nWelcome, {userName}!", Color.LightGreen);
                    return userName;
                }
                
                Console.WriteLine("Please enter a valid name.", Color.Red);
            }
        }

        static void DisplayMainMenu(string userName)
        {
            var cyberKnowledge = new CybersecurityKnowledgeBase();
            
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"\nHello {userName}! Main Menu:", Color.Cyan);
                Console.WriteLine(new string('=', 40), Color.DarkCyan);
                Console.WriteLine("1. Banking Fraud Protection", Color.White);
                Console.WriteLine("2. Phishing Scams", Color.White);
                Console.WriteLine("3. Password Security", Color.White);
                Console.WriteLine("4. SIM Swap Protection", Color.White);
                Console.WriteLine("5. Social Media Risks", Color.White);
                Console.WriteLine("6. Public WiFi Safety", Color.White);
                Console.WriteLine("7. Report a Cybercrime", Color.White);
                Console.WriteLine("8. Exit", Color.Red);
                Console.WriteLine(new string('=', 40), Color.DarkCyan);
                Console.Write("Enter your choice (1-8): ", Color.Yellow);

                string choice = Console.ReadLine()?.Trim();

                switch (choice)
                {
                    case "1":
                        DisplayBankingInfo(cyberKnowledge);
                        break;
                    case "2":
                        DisplayPhishingInfo(cyberKnowledge);
                        break;
                    case "3":
                        DisplayPasswordInfo(cyberKnowledge);
                        break;
                    case "4":
                        DisplaySimSwapInfo(cyberKnowledge);
                        break;
                    case "5":
                        DisplaySocialMediaInfo(cyberKnowledge);
                        break;
                    case "6":
                        DisplayWifiSafetyInfo(cyberKnowledge);
                        break;
                    case "7":
                        DisplayReportOptions();
                        break;
                    case "8":
                        DisplayExitMessage(userName);
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please enter 1-8.", Color.Red);
                        Thread.Sleep(1500);
                        break;
                }
            }
        }

        static void DisplayBankingInfo(CybersecurityKnowledgeBase cyberKnowledge)
        {
            Console.Clear();
            Console.WriteLine("\nBanking Fraud Protection (South Africa):", Color.Cyan);
            Console.WriteLine(new string('=', 60), Color.DarkCyan);
            Console.WriteLine(cyberKnowledge.GetResponse("banking"), Color.White);
            Console.WriteLine("\nRecent SA Banking Scams:", Color.Yellow);
            Console.WriteLine("- Fake 'card blocked' SMS with links to phishing sites");
            Console.WriteLine("- Fraudulent calls pretending to be from your bank");
            Console.WriteLine("- Fake banking apps on unofficial app stores");
            Console.WriteLine(new string('-', 60), Color.DarkCyan);
            Console.WriteLine("\nPress any key to return to menu...", Color.Gray);
            Console.ReadKey();
        }

        static void DisplayPhishingInfo(CybersecurityKnowledgeBase cyberKnowledge)
        {
            Console.Clear();
            Console.WriteLine("\nPhishing Scams in South Africa:", Color.Cyan);
            Console.WriteLine(new string('=', 60), Color.DarkCyan);
            Console.WriteLine(cyberKnowledge.GetResponse("phishing"), Color.White);
            Console.WriteLine("\nHow to Verify Legitimate Messages:", Color.Yellow);
            Console.WriteLine("- Check sender email/phone (often slightly misspelled)");
            Console.WriteLine("- Hover over links to see real destination");
            Console.WriteLine("- Contact the company using official website/phone");
            Console.WriteLine(new string('-', 60), Color.DarkCyan);
            Console.WriteLine("\nPress any key to return to menu...", Color.Gray);
            Console.ReadKey();
        }

        static void DisplayPasswordInfo(CybersecurityKnowledgeBase cyberKnowledge)
        {
            Console.Clear();
            Console.WriteLine("\nPassword Security Guidelines:", Color.Cyan);
            Console.WriteLine(new string('=', 60), Color.DarkCyan);
            Console.WriteLine(cyberKnowledge.GetResponse("password"), Color.White);
            Console.WriteLine("\nPassword Manager Recommendations:", Color.Yellow);
            Console.WriteLine("- Bitwarden (Free)");
            Console.WriteLine("- LastPass (Free and Paid)");
            Console.WriteLine("- 1Password (Paid)");
            Console.WriteLine("- Keeper (Paid)");
            Console.WriteLine(new string('-', 60), Color.DarkCyan);
            Console.WriteLine("\nPress any key to return to menu...", Color.Gray);
            Console.ReadKey();
        }

        static void DisplaySimSwapInfo(CybersecurityKnowledgeBase cyberKnowledge)
        {
            Console.Clear();
            Console.WriteLine("\nSIM Swap Fraud Prevention:", Color.Cyan);
            Console.WriteLine(new string('=', 60), Color.DarkCyan);
            Console.WriteLine(cyberKnowledge.GetResponse("simswap"), Color.White);
            Console.WriteLine("\nSA Mobile Provider Security Numbers:", Color.Yellow);
            Console.WriteLine("- Vodacom: 082 1944");
            Console.WriteLine("- MTN: 083 1234");
            Console.WriteLine("- Cell C: 084 140");
            Console.WriteLine("- Telkom: 081 180");
            Console.WriteLine(new string('-', 60), Color.DarkCyan);
            Console.WriteLine("\nPress any key to return to menu...", Color.Gray);
            Console.ReadKey();
        }

        static void DisplaySocialMediaInfo(CybersecurityKnowledgeBase cyberKnowledge)
        {
            Console.Clear();
            Console.WriteLine("\nSocial Media Risks:", Color.Cyan);
            Console.WriteLine(new string('=', 60), Color.DarkCyan);
            Console.WriteLine("- Oversharing personal information", Color.White);
            Console.WriteLine("- Fake profiles/friend requests", Color.White);
            Console.WriteLine("- Malicious links in messages", Color.White);
            Console.WriteLine("- Location tagging revealing your movements", Color.White);
            Console.WriteLine("\nPrivacy Settings Checklist:", Color.Yellow);
            Console.WriteLine("- Set profiles to private");
            Console.WriteLine("- Disable location tagging");
            Console.WriteLine("- Review friend lists regularly");
            Console.WriteLine("- Enable login notifications");
            Console.WriteLine(new string('-', 60), Color.DarkCyan);
            Console.WriteLine("\nPress any key to return to menu...", Color.Gray);
            Console.ReadKey();
        }

        static void DisplayWifiSafetyInfo(CybersecurityKnowledgeBase cyberKnowledge)
        {
            Console.Clear();
            Console.WriteLine("\nPublic WiFi Safety:", Color.Cyan);
            Console.WriteLine(new string('=', 60), Color.DarkCyan);
            Console.WriteLine("- Never do banking on public WiFi", Color.White);
            Console.WriteLine("- Use VPN when connecting to public networks", Color.White);
            Console.WriteLine("- Verify network names with venue staff", Color.White);
            Console.WriteLine("- Disable file sharing when on public networks", Color.White);
            Console.WriteLine("\nRecommended VPN Services:", Color.Yellow);
            Console.WriteLine("- ProtonVPN (Free and Paid)");
            Console.WriteLine("- NordVPN");
            Console.WriteLine("- Surfshark");
            Console.WriteLine("- ExpressVPN");
            Console.WriteLine(new string('-', 60), Color.DarkCyan);
            Console.WriteLine("\nPress any key to return to menu...", Color.Gray);
            Console.ReadKey();
        }

        static void DisplayReportOptions()
        {
            Console.Clear();
            Console.WriteLine("\nReport Cybercrime in South Africa:", Color.Cyan);
            Console.WriteLine(new string('=', 60), Color.DarkCyan);
            Console.WriteLine("1. South African Police Service (SAPS)", Color.White);
            Console.WriteLine("   - Visit local police station", Color.Gray);
            Console.WriteLine("   - Call 10111 for emergencies", Color.Gray);
            Console.WriteLine("\n2. South African Banking Risk Centre", Color.White);
            Console.WriteLine("   - Phone: 011 847 3000", Color.Gray);
            Console.WriteLine("   - Email: info@sabric.co.za", Color.Gray);
            Console.WriteLine("\n3. Report Phishing to Banks:", Color.White);
            Console.WriteLine("   - Forward suspicious emails to your bank", Color.Gray);
            Console.WriteLine("\n4. Report Online Fraud:", Color.White);
            Console.WriteLine("   - www.cybersmart.gov.za", Color.Gray);
            Console.WriteLine("   - www.cert.gov.za", Color.Gray);
            Console.WriteLine(new string('-', 60), Color.DarkCyan);
            Console.WriteLine("\nPress any key to return to menu...", Color.Gray);
            Console.ReadKey();
        }

        static void DisplayExitMessage(string userName)
        {
            Console.Clear();
            Console.WriteLine($"\nStay safe online, {userName}!", Color.Green);
            Console.WriteLine("Remember these key tips in South Africa:", Color.White);
            Console.WriteLine("- Never share OTPs or banking details", Color.Yellow);
            Console.WriteLine("- Verify unexpected messages with official channels", Color.Yellow);
            Console.WriteLine("- Keep software updated to prevent exploits", Color.Yellow);
            Console.WriteLine("\nApplication closing in 5 seconds...", Color.Gray);
            Thread.Sleep(5000);
        }
    }

    class CybersecurityKnowledgeBase
    {
        private readonly Dictionary<string, List<string>> responses;
        private readonly Random rand = new Random();

        public CybersecurityKnowledgeBase()
        {
            responses = new Dictionary<string, List<string>>()
            {
                ["password"] = new List<string> {
                    "In SA, strong passwords are critical due to high fraud rates:\n" +
                    "- Use 12+ characters with mixed cases, numbers & symbols\n" +
                    "- Never use personal info (ID numbers, birthdays)\n" +
                    "- Enable 2FA on all banking and email accounts\n" +
                    "Example of strong SA password: 'TableMountain@2023!'"
                },
                ["phishing"] = new List<string> {
                    "Common SA phishing scams to watch for:\n" +
                    "1. Fake banking messages (FNB, ABSA, Standard Bank lookalikes)\n" +
                    "2. SARS eFiling refund scams\n" +
                    "3. Courier delivery notifications with malicious links\n" +
                    "4. Fake job offers requesting personal details\n\n" +
                    "Always verify by contacting the company directly using official channels."
                },
                ["banking"] = new List<string> {
                    "SA Banking Safety Tips:\n" +
                    "1. Never share your PIN, OTP or banking details\n" +
                    "2. Register for your bank's fraud alert services\n" +
                    "3. Only use official banking apps from app stores\n" +
                    "4. Check statements regularly for suspicious transactions\n" +
                    "5. Report lost/stolen cards immediately"
                },
                ["simswap"] = new List<string> {
                    "SIM Swap Fraud Prevention:\n" +
                    "- Contact your mobile provider to add SIM swap protection\n" +
                    "- Never share verification codes received via SMS\n" +
                    "- If you lose signal unexpectedly, contact your bank\n" +
                    "- Use authentication apps instead of SMS where possible"
                }
            };
        }

        public string GetResponse(string topic)
        {
            if (responses.ContainsKey(topic))
            {
                var options = responses[topic];
                return options[rand.Next(options.Count)];
            }
            return "Information on this topic is not currently available.";
        }
    }
}