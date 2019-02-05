using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VRCSDK2;

namespace ExpansionTools.LipSyncSelect.tmp
{
    public interface ITmpInterface
    {
        Dictionary<VRC_AvatarDescriptor.Viseme, string> GetDataSet();
    }
}
