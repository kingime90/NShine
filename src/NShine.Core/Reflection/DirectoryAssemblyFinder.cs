﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace NShine.Core.Reflection
{
    /// <summary>
    /// 目录程序集查找器。
    /// </summary>
    public class DirectoryAssemblyFinder : AssemblyFinderBase, IAssemblyFinder
    {
        /// <summary>
        /// 程序集缓存。
        /// </summary>
        private static readonly IDictionary<string, Assembly[]> AssembliesCache = new Dictionary<string, Assembly[]>();

        private readonly string _path;

        /// <summary>
        /// 初始化一个<see cref="DirectoryAssemblyFinder"/>类型的新实例。
        /// </summary>
        public DirectoryAssemblyFinder()
            : this(GetBinPath())
        {

        }

        /// <summary>
        /// 初始化一个<see cref="DirectoryAssemblyFinder"/>类型的新实例。
        /// </summary>
        public DirectoryAssemblyFinder(string path)
        {
            _path = path;
        }

        /// <summary>
        /// 查找所有项。
        /// </summary>
        /// <returns></returns>
        public override Assembly[] FindAll()
        {
            Assembly[] assemblies = null;
            if (AssembliesCache.TryGetValue(_path, out assemblies))
            {
                return assemblies;
            }
            string[] files = Directory.GetFiles(_path, "*.dll", SearchOption.TopDirectoryOnly)
                .Concat(Directory.GetFiles(_path, "*.exe", SearchOption.TopDirectoryOnly))
                .ToArray();
            assemblies = files.Select(Assembly.LoadFrom).Distinct().ToArray();
            AssembliesCache.Add(_path, assemblies);
            return assemblies;
        }

        private static string GetBinPath()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;
            return path == Environment.CurrentDirectory + "\\" ? path : Path.Combine(path, "bin");
        }
    }
}
