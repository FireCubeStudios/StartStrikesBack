using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace StartStrikesBack.Core.Files
{
    /// <summary>
    /// Interface representing a file system folder to save files
    /// </summary>
    public interface IFolder
    {
        /// <summary> Name of the folder</summary>
        public string Name { get; }
        /// <summary>
        /// Creates a folder named with <paramref name="Name"/> in the current folder  asynchronously
        /// </summary>
        /// <param name="Name">The name of the folder</param>
        /// <returns>An IFolder asynchronously</returns>
        Task<IFolder> CreateFolderAsync(string Name);

        /// <summary>
        /// Retrieves an IFolder with the <paramref name="Name"/>in the current folder
        /// </summary>
        /// <param name="Name">The name of the folder</param>
        /// <returns>An IFolder asynchronously</returns>
        Task<IFolder> GetFolderAsync(string Name);

        /// <summary>
        /// Creates a file named with <paramref name="Name"/> in the current folder asynchronously
        /// </summary>
        /// <param name="Name">The name of the file</param>
        /// <returns>An IFile asynchronously</returns>
        Task<IFile> CreateFileAsync(string Name);

        /// <summary>
        /// Add an <paramref name="File"/> to the folder asynchronously
        /// </summary>
        /// <param name="File">The IFile to add to the folder</param>
        /// <returns>A bool indicating success of operation</returns>
        Task<bool> AddFileAsync(IFile File);

        /// <summary>
        /// Retrieves an IFile with the <paramref name="Name"/>in the current folder
        /// </summary>
        /// <param name="Name">The name of the file</param>
        /// <returns>An IFile asynchronously</returns>
        Task<IFile> GetFileAsync(string Name);

        /// <summary> Deletes the current folder</summary>
        Task DeleteAsync();
    }
}
