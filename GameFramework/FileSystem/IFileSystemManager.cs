﻿//------------------------------------------------------------
// Game Framework
// Copyright © 2013-2020 Jiang Yin. All rights reserved.
// Homepage: https://gameframework.cn/
// Feedback: mailto:ellan@gameframework.cn
//------------------------------------------------------------

using System.Collections.Generic;

namespace GameFramework.FileSystem
{
    /// <summary>
    /// 文件系统管理器。
    /// </summary>
    public interface IFileSystemManager
    {
        /// <summary>
        /// 获取文件系统数量。
        /// </summary>
        int Count
        {
            get;
        }

        /// <summary>
        /// 创建文件系统。
        /// </summary>
        /// <param name="fullPath">要创建的文件系统的完整路径。</param>
        /// <param name="access">要创建的文件系统的访问方式。</param>
        /// <param name="maxFileCount">要创建的文件系统的最大文件数量。</param>
        /// <param name="maxBlockCount">要创建的文件系统的最大块数据数量。</param>
        /// <returns>创建的文件系统。</returns>
        IFileSystem CreateFileSystem(string fullPath, FileSystemAccess access, int maxFileCount, int maxBlockCount);

        /// <summary>
        /// 加载文件系统。
        /// </summary>
        /// <param name="fullPath">要加载的文件系统的完整路径。</param>
        /// <param name="access">要加载的文件系统的访问方式。</param>
        /// <returns>加载的文件系统。</returns>
        IFileSystem LoadFileSystem(string fullPath, FileSystemAccess access);

        /// <summary>
        /// 销毁文件系统。
        /// </summary>
        /// <param name="fileSystem">要销毁的文件系统。</param>
        /// <param name="deletePhysicalFile">是否删除文件系统对应的物理文件。</param>
        void DestroyFileSystem(IFileSystem fileSystem, bool deletePhysicalFile);

        /// <summary>
        /// 注册文件系统。
        /// </summary>
        /// <param name="name">要注册的文件系统的名称。</param>
        /// <param name="fileSystem">要注册的文件系统。</param>
        /// <returns>注册的文件系统是否成功。</returns>
        bool RegisterFileSystem(string name, IFileSystem fileSystem);

        /// <summary>
        /// 解除注册文件系统。
        /// </summary>
        /// <param name="name">要解除注册的文件系统的名称。</param>
        /// <param name="fileSystem">要解除注册的文件系统。</param>
        /// <returns>解除注册的文件系统是否成功。</returns>
        bool UnregisterFileSystem(string name, IFileSystem fileSystem);

        /// <summary>
        /// 获取文件系统。
        /// </summary>
        /// <param name="name">要获取的文件系统的名称。</param>
        /// <returns>获取的文件系统。</returns>
        IFileSystem GetFileSystem(string name);

        /// <summary>
        /// 获取文件系统。
        /// </summary>
        /// <param name="name">要获取的文件系统的名称。</param>
        /// <param name="access">要获取的文件系统的访问方式。</param>
        /// <returns>获取的文件系统。</returns>
        IFileSystem GetFileSystem(string name, FileSystemAccess access);

        /// <summary>
        /// 获取文件系统集合。
        /// </summary>
        /// <param name="name">要获取的文件系统的名称。</param>
        /// <returns>获取的文件系统集合。</returns>
        IFileSystem[] GetFileSystems(string name);

        /// <summary>
        /// 获取文件系统集合。
        /// </summary>
        /// <param name="name">要获取的文件系统的名称。</param>
        /// <param name="access">要获取的文件系统的访问方式。</param>
        /// <returns>获取的文件系统集合。</returns>
        IFileSystem[] GetFileSystems(string name, FileSystemAccess access);

        /// <summary>
        /// 获取文件系统集合。
        /// </summary>
        /// <param name="name">要获取的文件系统的名称。</param>
        /// <param name="results">获取的文件系统集合。</param>
        void GetFileSystems(string name, List<IFileSystem> results);

        /// <summary>
        /// 获取文件系统集合。
        /// </summary>
        /// <param name="name">要获取的文件系统的名称。</param>
        /// <param name="access">要获取的文件系统的访问方式。</param>
        /// <param name="results">获取的文件系统集合。</param>
        void GetFileSystems(string name, FileSystemAccess access, List<IFileSystem> results);

        /// <summary>
        /// 获取所有文件系统集合。
        /// </summary>
        /// <returns>获取的所有文件系统集合。</returns>
        IFileSystem[] GetAllFileSystems();

        /// <summary>
        /// 获取所有文件系统集合。
        /// </summary>
        /// <param name="results">获取的所有文件系统集合。</param>
        void GetAllFileSystems(List<IFileSystem> results);
    }
}
