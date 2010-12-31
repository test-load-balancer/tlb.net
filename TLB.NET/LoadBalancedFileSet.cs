using System;
using System.Collections.Specialized;
using System.Globalization;
using System.IO;
using System.Net;
using System.Text;
using NAnt.Core.Attributes;
using NAnt.DotNet.Types;
using TLBNETTasks;

namespace NAnt.Core.Types
{
    [ElementName("assemblies")]
    public class LoadBalancedFileSet : AssemblyFileSet
    {

        [BuildElementArray("loadbalancedincludes")]
        public LoadBalancedInclude[] LoadBalancedIncludes
        {
            set
            {
                foreach (LoadBalancedInclude include in value)
                {
                    if (include.IfDefined && !include.UnlessDefined)
                    {
                        if (include.AsIs)
                        {
                            AsIs.Add(include.Pattern);
                        }
                        else if (include.FromPath)
                        {
                            PathFiles.Add(include.Pattern);
                        }
                        else
                        {
                            Includes.Add(include.Pattern);
                        }
                    }
                }
            }
        }

        public override void Scan()
        {
            base.Scan();
            ResolveReferences();
            foreach (var fileName in FileNames)
            {
                Console.Out.WriteLine(fileName);
            }

            throw new NotImplementedException("In Scan()");
        }

    }
}