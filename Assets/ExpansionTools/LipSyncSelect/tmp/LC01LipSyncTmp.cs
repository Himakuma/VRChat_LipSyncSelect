using System.Collections.Generic;
using VRCSDK2;

namespace ExpansionTools.LipSyncSelect.tmp
{
    public class LC01LipSyncTmp : ITmpInterface
    {
        public Dictionary<VRC_AvatarDescriptor.Viseme, string> GetDataSet()
        {
            return new Dictionary<VRC_AvatarDescriptor.Viseme, string>
            {
                { VRC_AvatarDescriptor.Viseme.sil, "LC01.sil" },
                { VRC_AvatarDescriptor.Viseme.PP,  "LC01.sil"  },
                { VRC_AvatarDescriptor.Viseme.FF,  "LC01.sil"  },
                { VRC_AvatarDescriptor.Viseme.TH,  "LC01.ih"  },
                { VRC_AvatarDescriptor.Viseme.DD,  "LC01.ih"  },
                { VRC_AvatarDescriptor.Viseme.kk,  "LC01.ih"  },
                { VRC_AvatarDescriptor.Viseme.CH,  "LC01.ch"  },
                { VRC_AvatarDescriptor.Viseme.SS,  "LC01.ss"  },
                { VRC_AvatarDescriptor.Viseme.nn,  "LC01.ih"  },
                { VRC_AvatarDescriptor.Viseme.RR,  "LC01.ih"  },
                { VRC_AvatarDescriptor.Viseme.aa,  "LC01.aa"  },
                { VRC_AvatarDescriptor.Viseme.E,   "LC01.ch"   },
                { VRC_AvatarDescriptor.Viseme.ih,  "LC01.ih"  },
                { VRC_AvatarDescriptor.Viseme.oh,  "LC01.oh"  },
                { VRC_AvatarDescriptor.Viseme.ou,  "LC01.ou"  }
            };
        }
    }
}
