using System;
using System.Collections.Generic;
using System.Text;

namespace YSKProje.ToDo.Business.Interfaces
{
    public interface IFileService
    {

        /// <summary>
        /// Geriye üretmiş ve upload etmiş olduğu pdf dosyasının virtual pathini döner.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        string Pdf<T>(List<T> list) where T : class, new();
        /// <summary>
        /// Geriye excel verisini byte dizi olarak döner.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        byte[] Excel<T>(List<T> list) where T : class, new();
    }
}
