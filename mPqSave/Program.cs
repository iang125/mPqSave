using System;
using System.IO;
using System.Text;

namespace mPqSave
{
    public static class Program
    {
        public static int Main(string[] args)
        {
            if (args.Length < 3 ||
                args.Length > 0 && args[0] == "k" && args.Length < 5)
            {
                PrintUsage();
                return -1;
            }

            try
            {
                Run(args);
                return 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                return -1;
            }
        }

        private static void Run(string[] args)
        {
            byte[] key = null;
            int arg_mode_index = 0;
            int arg_input_data_index = 1;
            int arg_output_file_name_index = 2;
            int arg_script_start_index = 3;

            switch (args[0])
            {
                case "k":
                    {
                        key = Encoding.UTF8.GetBytes(args[1]);
                        arg_mode_index = 2;
                        arg_input_data_index = 3;
                        arg_output_file_name_index = 4;
                        arg_script_start_index = 5;
                    }
                    break;
                case "p":
                    {
                        key = File.ReadAllBytes(args[1]);
                        arg_mode_index = 2;
                        arg_input_data_index = 3;
                        arg_output_file_name_index = 4;
                        arg_script_start_index = 5;
                    }
                    break;
                default:
                    break;
            }

            byte[] input_data = File.ReadAllBytes(args[arg_input_data_index]);
            string output_file_name = args[arg_output_file_name_index];

            switch (args[arg_mode_index])
            {
                case "d":
                    File.WriteAllBytes(output_file_name, Encryption.DecryptSave(key, input_data));
                    break;
                case "e":
                    File.WriteAllBytes(output_file_name, Encryption.EncryptSave(key, input_data));
                    break;
                case "x":
                    var savex = new SaveManager(key, input_data);
                    var output = Json.Serialize(savex);
                    File.WriteAllText(output_file_name, output);
                    break;
                case "i":
                    SaveManager savei = Json.DeSerialize(Encoding.UTF8.GetString(input_data));
                    File.WriteAllBytes(output_file_name, savei.Export(key));
                    break;
                case "s":
                    var save = new SaveManager(key, input_data);

                    for (int i = arg_script_start_index; i < args.Length; i++)
                    {
                        Scripting.RunScript(save.SerializeData, args[i]);
                    }

                    File.WriteAllBytes(output_file_name, save.Export(key));
                    break;
                default:
                    PrintUsage();
                    return;
            }
        }

        private static void PrintUsage()
        {
            Console.WriteLine("Usage: mpqsave [[k key] | [p keyfile]] mode input output [script1 (In script mode only)] [script2]...");
            Console.WriteLine("  modes:");
            Console.WriteLine("    k Key (string, mobile version need)");
            Console.WriteLine("    p Key file (file, mobile version need)");
            Console.WriteLine("    d Decrypt save (input: encrypted save, output: decrypted save)");
            Console.WriteLine("    e Encrypt save (input: decrypted save, output: encrypted save)");
            Console.WriteLine("    x Export save to JSON (input: encrypted save, output: json)");
            Console.WriteLine("    i Import save from JSON (input: json, output: encrypted save)");
            Console.WriteLine("    s Script - Run scripts on an encrypted save (input: encrypted save, output: modified encrypted save)");
            Console.WriteLine("  option k and p only need one");
        }
    }
}
