using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Selene.Core
{
    /// <summary>
    /// 用于给 await 确定异步返回的时机。
    /// </summary>
    public interface IAwaiter : INotifyCompletion
    {       
        bool IsCompleted { get; }

     
        void GetResult();
    }

    public interface IAwaiter<out TResult> : INotifyCompletion
    {        
        bool IsCompleted { get; }
      
        TResult GetResult();
    }
  
    public interface IAwaitable<out TAwaiter> where TAwaiter : IAwaiter
    {      
        TAwaiter GetAwaiter();
    }
  
    public interface IAwaitable<out TAwaiter, out TResult> where TAwaiter : IAwaiter<TResult>
    {
        TAwaiter GetAwaiter();
    }
  
    public interface ICriticalAwaiter : IAwaiter, ICriticalNotifyCompletion
    {
    }
  
    public interface ICriticalAwaiter<out TResult> : IAwaiter<TResult>, ICriticalNotifyCompletion
    {
    }
}
