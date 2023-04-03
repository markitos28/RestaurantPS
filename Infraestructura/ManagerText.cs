using Aplicacion.Interfaces;

namespace SlnManagerText
{
    public class ManagerText: IManagerText
    {
        private string _ruta;
        private string _log;
        public ManagerText(string ruta)
        {
            try
            {
                if (!Directory.Exists(@ruta))
                {
                    Directory.CreateDirectory(ruta);
                }
                _ruta = ruta;
                _log = "log_" + DateTime.Today.ToString("yyyyMMdd") + ".txt";
            }

            catch (DirectoryNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        }

        /// <summary>
        /// Crea el archivo log para salvar la informacion del programa
        /// </summary>
        /// <returns>Retorna un booleano indicando si se creo satisfactoriamente</returns>
        public bool createLog()
        {
            try
            {
                if(!File.Exists(_ruta + "\\" + _log))
                {
                    StreamWriter file = File.CreateText(_ruta + "\\" + _log);
                    file.Close();
                }
                return true;
            }
            catch (FileLoadException e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        /// <summary>
        /// Escribe una nueva linea en el archivo del dia
        /// </summary>
        /// <param name="lineCode"></param>
        /// <param name="messaje"></param>
        public void writeLog(string messaje)
        {
            try
            {
                StreamWriter file = File.AppendText(_ruta + "\\" + _log);
                file.WriteLine(messaje + " - " + DateTime.Now.ToString("HH:mm:ss"));
                file.Close();
            }
            catch( FileLoadException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("No se pudo cargar el archivo");
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("El archivo no se encontro");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Busca logs en la ruta informada por el objeto mediante la fecha que se informa por parametro
        /// </summary>
        /// <param name="dateLog"></param>
        /// <returns> Retorna lista con los nombres de los logs que contiene el path </returns>
        public List<string> findDateLogs(DateTime dateLog)
        {
            try
            {
                List<string> namesLogs = new List<string>();
                var logs = new DirectoryInfo(_ruta).GetFiles("*" + dateLog.ToString("yyyyMMdd"));
                for(int i = 0; i < logs.Length; i++)
                {
                    namesLogs.Add(logs[i].Name);
                }
                return namesLogs;
            }
            catch(ArgumentNullException e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
            catch(PathTooLongException e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }

        }

        /// <summary>
        /// Lee el log creado por el objeto
        /// </summary>
        /// <returns> Retorna las lineas contenidas en el log como una list<string> </returns>
        public List<string> readLog()
        {
            try
            {
                StreamReader readLog = File.OpenText(_ruta + "\\" + _log);
                List<string> logsTxt = new List<string>();
                while (!readLog.EndOfStream)
                {
                    string line = readLog.ReadLine();
                    if (line != null)
                    {
                        logsTxt.Add(line);
                    }
                }
                readLog.Close();
                return logsTxt;
            }
            catch(UnauthorizedAccessException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Error de autorizacion para leer el archivo");
                return null;
            }
            catch(DirectoryNotFoundException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Error: El directorio no existe.");
                return null;
            }
            catch(FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Error: El archivo no existe.");
                return null;
            }
            catch(ArgumentException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Error: Los argumentos informados en la función son nulos.");
                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public bool resetLog()
        {
            try
            {
                if (File.Exists(_ruta + "\\" + _log))
                {
                    StreamWriter file = File.CreateText(_ruta + "\\" + _log);
                    file.Close();
                    return true;
                }
                else
                {
                    return false;
                }
                
            }
            catch (FileLoadException e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }


    }
}
