using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StartStrikesBack.Core.Files
{
    /// <summary>
    /// Interface for a service to store folders in local storage
    /// </summary>
    public interface ILocalFolderService
    {
        /// <summary>
        /// Retrieves a folder with name <paramref name="FolderName"/> from the local storage folder
        /// </summary>
        /// <param name="FolderName">The name of the folder to retrieve</param>
        /// <returns>>The retrieved folder</returns>
        Task<IFolder> GetLocalFolderAsync(string FolderName);

        /// <summary>
        /// Creates a folder with name <paramref name="FolderName"/> in the local storage folder
        /// </summary>
        /// <param name="FolderName">The name of the folder to create</param>
        /// <returns>The created folder</returns>
        Task<IFolder> CreateLocalFolderAsync(string FolderName);
    }
}
