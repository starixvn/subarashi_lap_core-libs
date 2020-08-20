using System;
using System.Threading.Tasks;

namespace Fanex.Core.Utils
{
    public sealed class AsyncLazy<T>
    {
        private Lazy<Task<T>> _lazyTaskFactory;
        private readonly Func<Task<T>> _taskFactory;
        private readonly object _lazyInitializationGuard = new object();

        public AsyncLazy(Func<Task<T>> taskFactory)
        {
            _taskFactory = taskFactory;
            _lazyTaskFactory = InitLazy(_taskFactory);
        }

        public Task<T> Value
        {
            get
            {
                if (!(_lazyTaskFactory.IsValueCreated && _lazyTaskFactory.Value.IsFaulted))
                {
                    return _lazyTaskFactory.Value;
                }

                lock (_lazyInitializationGuard)
                {
                    if (_lazyTaskFactory.IsValueCreated && _lazyTaskFactory.Value.IsFaulted)
                    {
                        _lazyTaskFactory = InitLazy(_taskFactory);
                    }

                    return _lazyTaskFactory.Value;
                }
            }
        }

        private static Lazy<Task<T>> InitLazy(Func<Task<T>> taskFactory)
        {
            return new Lazy<Task<T>>(taskFactory);
        }
    }
}