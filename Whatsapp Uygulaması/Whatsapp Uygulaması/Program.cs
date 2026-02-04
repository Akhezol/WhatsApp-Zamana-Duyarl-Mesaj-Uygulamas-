using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Whatsapp_Uygulamasi
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.Write("Mesaj gönderim saati (HH:mm): ");
            string timeInput = Console.ReadLine();

            if (!TimeSpan.TryParse(timeInput, out TimeSpan targetTime))
            {
                Console.WriteLine("Saat formatı hatalı!");
                return;
            }

            Console.Write("Mesaj gönderilecek kişi adı: ");
            string contactName = Console.ReadLine();

            Console.Write("Gönderilecek mesaj: ");
            string messageText = Console.ReadLine();

            DateTime now = DateTime.Now;
            DateTime sendTime = now.Date + targetTime;
            if (sendTime < now)
                sendTime = sendTime.AddDays(1);

            Console.WriteLine($"Mesaj {sendTime:HH:mm} saatinde gönderilecek...");
            await Task.Delay(sendTime - now);

            SendWhatsAppMessage(contactName, messageText);

            Console.WriteLine("Mesaj gönderildi. Çıkmak için bir tuşa bas.");
            Console.ReadKey();
        }

        static void SendWhatsAppMessage(string contactName, string messageText)
        {
           
            Process.Start("explorer.exe",
                "shell:AppsFolder\\5319275A.WhatsAppDesktop_cv1g1gvanyjgm!App");

            Thread.Sleep(9000);

            IntPtr hwnd = GetWhatsAppHandle();
            if (hwnd == IntPtr.Zero)
            {
                Console.WriteLine("WhatsApp penceresi bulunamadı!");
                return;
            }

            ForceForegroundWindow(hwnd);
            Thread.Sleep(1500);

            
            SendKeys.SendWait("{ESC}");
            Thread.Sleep(300);

           
            SendKeys.SendWait("^f");
            Thread.Sleep(1200);

           
            SendKeys.SendWait(contactName);
            Thread.Sleep(1500);

            SendKeys.SendWait("{ENTER}");
            Thread.Sleep(1200);

            
            SendKeys.SendWait(messageText);
            Thread.Sleep(500);

            SendKeys.SendWait("{ENTER}");
        }

        static IntPtr GetWhatsAppHandle()
        {
            foreach (var p in Process.GetProcesses())
            {
                if (!string.IsNullOrEmpty(p.MainWindowTitle) &&
                    p.MainWindowTitle.Contains("WhatsApp"))
                {
                    return p.MainWindowHandle;
                }
            }
            return IntPtr.Zero;
        }

        static void ForceForegroundWindow(IntPtr hWnd)
        {
            IntPtr foregroundWindow = GetForegroundWindow();
            uint foreThread = GetWindowThreadProcessId(foregroundWindow, out _);
            uint appThread = GetWindowThreadProcessId(hWnd, out _);

            AttachThreadInput(foreThread, appThread, true);
            ShowWindow(hWnd, 9); 
            SetForegroundWindow(hWnd);
            AttachThreadInput(foreThread, appThread, false);
        }

        [DllImport("user32.dll")]
        static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint processId);

        [DllImport("user32.dll")]
        static extern bool AttachThreadInput(uint idAttach, uint idAttachTo, bool fAttach);
    }
}
