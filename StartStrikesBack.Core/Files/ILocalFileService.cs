using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace StartStrikesBack.Core.Files
{
    /// <summary>
    /// Interface for a service to store files in local storage
    /// </summary>
    public interface ILocalFileService
    {
        /// <summary>
        /// Get a file with name <paramref name="FileName"/> from the local storage folder asynchronously
        /// </summary>
        /// <param name="FileName">Name of file to retrieve</param>
        /// <returns>The retrieved file asynchronously</returns>
        Task<IFile> GetLocalFileAsync(string FileName);

        /// <summary>
        /// Creates a file with name <paramref name="FileName"/> in the local storage folder asynchronously
        /// </summary>
        /// <param name="FileName">Name of file to create</param>
        /// <returns>The created file asynchronously</returns>
        Task<IFile> CreateLocalFileAsync(string FileName);
    }
}
