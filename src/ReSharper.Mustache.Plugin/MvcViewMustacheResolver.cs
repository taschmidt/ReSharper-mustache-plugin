using System;
using System.Collections.Generic;
using JetBrains.ProjectModel;
using JetBrains.ReSharper.Feature.Services.Asp.CustomReferences;

namespace ReSharper.Mustache.Plugin
{
    public class MvcViewMustacheResolver : IMvcViewResolver
    {
        static MvcViewMustacheResolver()
        {
            
        }
        public bool IsApplicable(IProject project)
        {
            throw new NotImplementedException();
        }

        public IDictionary<MvcViewLocationType, ICollection<string>> Values { get; private set; }
    }
}
