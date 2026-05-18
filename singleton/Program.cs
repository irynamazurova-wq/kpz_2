#nullable disable
using System;

namespace SingletonPattern
{
    public sealed class Authenticator
    {
        private static Authenticator _instance;
        private static readonly object _lock = new object();
        
        public string CurrentUser { get; private set; }

        private Authenticator()
        {
            Console.WriteLine("=> Ініціалізація єдиного екземпляра автентифікатора...");
        }

        public static Authenticator Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new Authenticator();
                    }
                    return _instance;
                }
            }
        }

        public void Login(string username)
        {
            if (CurrentUser == null)
            {
                CurrentUser = username;
                Console.WriteLine($"[Успіх] Користувач {username} увійшов у систему.");
            }
            else
            {
                Console.WriteLine($"[Відмова] Вхід для {username} неможливий. Вже авторизовано: {CurrentUser}.");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("--- Перевірка патерну Одинак ---");

            var auth1 = Authenticator.Instance;
            var auth2 = Authenticator.Instance;

            auth1.Login("Admin");
            auth2.Login("Guest");

            Console.Write("auth1 і auth2 посилаються на один об'єкт? ");
            Console.WriteLine(ReferenceEquals(auth1, auth2)); 

            Console.ReadKey();
        }
    }
}