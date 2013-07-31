using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TapstreamMetrics.Sdk
{
    public interface IApi
    {
        void FireEvent(Event e);
        void FireHit(Hit h, Hit.Complete completion);
        Task<TSResponse> FireHitAsync(Hit h);
    }

    public interface ICoreListener
    {
        void ReportOperation(string op);
        void ReportOperation(string op, string arg);
    }

    public interface IDelegate
    {
        int GetDelay();
        void SetDelay(int delay);
        bool IsRetryAllowed();
    }

    public interface ILogger
    {
        void Log(LogLevel level, string msg);
    }

    public interface IPlatform
    {
        string GetUuid();
        HashSet<string> LoadFiredEvents();
        void SaveFiredEvents(HashSet<string> firedEvents);
        string GetResolution();
        string GetManufacturer();
        string GetModel();
        string GetOs();
        string GetLocale();
        string GetAppName();
        string GetPackageName();
        TSResponse Request(string url, string data);
    }
}