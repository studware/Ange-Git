using System;
using System.Collections.Generic;

namespace T3.BuildWindowsTree
{
    class File
    {
        public string Name { get; set; }
        public long Size { get; set; }

        public File(string name, long size)
        {
            this.Name = name;
            this.Size = size;
        }
    }
}
