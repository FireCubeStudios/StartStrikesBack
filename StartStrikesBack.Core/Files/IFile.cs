using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace StartStrikesBack.Core.Files
{
    /// <summary>
    /// Interface representing a file system file that can save data
    /// </summary>
    public interface IFile
    {
        /// <summary> Name of the file</summary>
        string Name { get; }
        /// <summary>
        /// Open the file as an IO <see cref="Stream"/> asynchronously
        /// </summary>
        /// <returns>An IO <see cref="Stream"/> of the file</returns>
        Task<Stream> OpenFileStreamAsync();
    }
}
