namespace Aplicacion.Interfaces
{
    public interface IManagerText
    {
        bool createLog();
        void writeLog(string messaje);
        List<string> findDateLogs(DateTime dateLog);
        List<string> readLog();
        bool resetLog();
    }
}
