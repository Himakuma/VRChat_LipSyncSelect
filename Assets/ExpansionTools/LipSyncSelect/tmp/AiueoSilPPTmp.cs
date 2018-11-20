using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VRCSDK2;

namespace Assets.ExpansionTools.LipSyncSelect.tmp
{
    public class AiueoSilPPTmp : ITmpInterface
    {
        public Dictionary<VRC_AvatarDescriptor.Viseme, string> GetDataSet()
        {
            return new Dictionary<VRC_AvatarDescriptor.Viseme, string>
            {
                { VRC_AvatarDescriptor.Viseme.sil, "Sil" },
                { VRC_AvatarDescriptor.Viseme.PP, "PP" },
                { VRC_AvatarDescriptor.Viseme.FF, "i" },
                { VRC_AvatarDescriptor.Viseme.TH, "i" },
                { VRC_AvatarDescriptor.Viseme.DD, "e" },
                { VRC_AvatarDescriptor.Viseme.kk, "e" },
                { VRC_AvatarDescriptor.Viseme.CH, "i" },
                { VRC_AvatarDescriptor.Viseme.SS, "i" },
                { VRC_AvatarDescriptor.Viseme.nn, "e" },
                { VRC_AvatarDescriptor.Viseme.RR, "e" },
                { VRC_AvatarDescriptor.Viseme.aa, "a" },
                { VRC_AvatarDescriptor.Viseme.E, "e" },
                { VRC_AvatarDescriptor.Viseme.ih, "i" },
                { VRC_AvatarDescriptor.Viseme.oh, "o" },
                { VRC_AvatarDescriptor.Viseme.ou, "u" }
            };
        }
    }
}
