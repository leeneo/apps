using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json; //不要管红线提示，程序可以正常运行
using Microsoft.Extensions.Logging;

namespace CSharp {
    class LogTest {

        public static void Run () { 
            var log=new Logger("fileName","D:\\");
        }

        public class Logger : ILogger {
            private readonly string _categoryName;
            private readonly string _filePath;

            public Logger (string categoryName, string filePath) {
                _categoryName = categoryName;
                _filePath = filePath;
            }

            public bool IsEnabled (LogLevel logLevel) {
                return true;
                //throw new NotImplementedException();
            }

            public void Log<TState> (LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter) {
                try {
                    RecordMsg (logLevel, eventId, state, exception, formatter);
                } catch {
                    RecordMsg (logLevel, eventId, state, exception, formatter);
                }
                //throw new NotImplementedException();
            }
            private void RecordMsg<TState> (LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter) {
                string msg = $"{logLevel}::{_categoryName}::{formatter(state, exception)} " +
                    $":: username ::{DateTime.Now}";
                using (var writer = File.AppendText (_filePath)) {
                    writer.WriteLine ();
                }
                //throw new NotImplementedException();
            }
            public IDisposable BeginScope<TState> (TState state) {
                return new NoopDisposable ();
                //throw new NotImplementedException();
            }

            private class NoopDisposable : IDisposable {
                public void Dispose () { }
            }

        }

    }
}