using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OSIO3
{
    public partial class Form1 : Form
    {

        
        public Form1()
        {
            InitializeComponent();
            
        }

        private void button_file_Click(object sender, EventArgs e)
        {
            Form Form2 = new Form2();
            Form2.Show();
        }

      
     

        public void consondeb()
        {
            if (NativeMethods.AllocConsole())
            {
                IntPtr stdHandle = NativeMethods.GetStdHandle(NativeMethods.STD_OUTPUT_HANDLE);

                caseComands();
            }
            else
            {
                Console.WriteLine("Консоль Активна!");
            }

        }

        public void caseComands()
        {
            string path = @"C:/Users/mrher/Desktop/";
            string pathtwo = @"C:/Users/mrher/Desktop/z";

            Console.WriteLine("Список доступных команд:" +
                "\n1) mkdir создает каталог по указанному пути path" +
                "\n2) rm удаляет каталог по указанному пути path" +
                "\n3) ex определяет, существует ли каталог по указанному пути path.Если существует, возвращается true, если не существует, то false" +
                "\n4) ls получает список каталогов в каталоге path" + 
                "\n5) cat получает список файлов в каталоге path" +
                "\n6) pwd получение родительского каталога" +
                "\n7) mv перемещает каталог" +
                "\n8) cp копирует существующий файл в новый файл" +
                "\n9) touch создает файл" +
                "\n10) date показывает текущее время" +
                "\n11) task доп задание, показывающее ограничение файловой системы");

            Console.WriteLine("\n\nВыберите команду, которую хотите вызвать");

            string caseSwitch = Console.ReadLine();

            while (caseSwitch != "0")
            {
                switch (caseSwitch)
                {
                    case "mkdir":
                        Console.WriteLine(1);
                        Directory.CreateDirectory(path + "catalog");
                        break;

                    case "rm":
                        Console.WriteLine(2);
                        Directory.Delete(path + "catalog");
                        break;

                    case "ex":
                        Console.WriteLine(Directory.Exists(path + "catalog"));               
                        break;

                    case "ls":
                        string[] dirs = Directory.GetDirectories(pathtwo);
                        for (int i = 0; i < dirs.Length; i++)   {   Console.WriteLine(dirs[i]); }
                        break;

                    case "cat":
                        string[] files = Directory.GetFiles(pathtwo);
                        for (int i = 0; i < files.Length; i++) { Console.WriteLine(files[i]); }
                        break;

                    case "pwd":
                        Console.WriteLine(Directory.GetParent(path));
                        break;

                    case "mv":
                        Directory.Move(pathtwo + "/12345.txt", path + "q/12345.txt");
                        break;

                    case "cp":
                        Console.WriteLine(8);
                        File.Copy(path + "test.txt", pathtwo + "/test2.txt", true);
                        break;

                    case "touch":
                        Console.WriteLine(9);
                        FileStream file = new FileStream(path + "test.txt", FileMode.Create);
                        break;
                    case "date":
                        Console.WriteLine(10);
                        Console.WriteLine(DateTime.Now);
                        break;
                    case "task":
                        Console.WriteLine(11);
                        Task();
                        break;
                    default:
                        Console.WriteLine("Введена неверная команда!");
                        break;
                }
                Console.WriteLine("Для выхода нажмите '0' ");
                caseSwitch = Console.ReadLine();
            }
            Environment.Exit(0);
        }

        public void Task()
        {
            string path = @"C:/Users/mrher/Desktop/taskEx";
            int q = 0;
            long dirSize = SafeEnumerateFiles(path, "*.*", SearchOption.AllDirectories).Sum(n => new FileInfo(n).Length);

            Console.WriteLine(dirSize);

            

            try
            {
                while (true)
                {
                    using (FileStream file = new FileStream(path + "/" + Convert.ToString(q), FileMode.Create))
                    using (StreamWriter stream = new StreamWriter(file))
                        stream.WriteLine("Я в надежде получить автомат у Сергея Валеривича");
   

                    dirSize = SafeEnumerateFiles(path, "*.*", SearchOption.AllDirectories).Sum(n => new FileInfo(n).Length);
                    q++;

                    if (dirSize > 50000)
                    {
                        throw new Exception("Вы вышли за максимальный размер тома!");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка! " + ex.Message);
            }
            

        }
        public partial class NativeMethods
        {
            public static Int32 STD_OUTPUT_HANDLE = -11;

            [System.Runtime.InteropServices.DllImportAttribute("kernel32.dll", EntryPoint = "GetStdHandle")]
            public static extern System.IntPtr GetStdHandle(Int32 nStdHandle);

            [System.Runtime.InteropServices.DllImportAttribute("kernel32.dll", EntryPoint = "AllocConsole")]
            [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.Bool)]
            public static extern bool AllocConsole();
        }


        private void button3_Click_1(object sender, EventArgs e)
        {
            consondeb();
        }



        private static IEnumerable<string> SafeEnumerateFiles(string path, string searchPattern = "*.*", SearchOption searchOption = SearchOption.TopDirectoryOnly)
        {
            var dirs = new Stack<string>();
            dirs.Push(path);

            while (dirs.Count > 0)
            {
                string currentDirPath = dirs.Pop();
                if (searchOption == SearchOption.AllDirectories)
                {
                    try
                    {
                        string[] subDirs = Directory.GetDirectories(currentDirPath);
                        foreach (string subDirPath in subDirs)
                        {
                            dirs.Push(subDirPath);
                        }
                    }
                    catch (UnauthorizedAccessException)
                    {
                        continue;
                    }
                    catch (DirectoryNotFoundException)
                    {
                        continue;
                    }
                }

                string[] files = null;
                try
                {
                    files = Directory.GetFiles(currentDirPath, searchPattern);
                }
                catch (UnauthorizedAccessException)
                {
                    continue;
                }
                catch (DirectoryNotFoundException)
                {
                    continue;
                }

                foreach (string filePath in files)
                {
                    yield return filePath;
                }
            }
        }

  
    }
}
    
