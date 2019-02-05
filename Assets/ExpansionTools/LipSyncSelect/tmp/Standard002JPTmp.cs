using System.Collections.Generic;
using VRCSDK2;

namespace ExpansionTools.LipSyncSelect.tmp
{
    public class Standard002JPTmp : ITmpInterface
    {
        public Dictionary<VRC_AvatarDescriptor.Viseme, string> GetDataSet()
        {
            return new Dictionary<VRC_AvatarDescriptor.Viseme, string>
            {
                { VRC_AvatarDescriptor.Viseme.sil, "あ" },
                { VRC_AvatarDescriptor.Viseme.PP,  "あ"  },
                { VRC_AvatarDescriptor.Viseme.FF,  "あ"  },
                { VRC_AvatarDescriptor.Viseme.TH,  "い"  },
                { VRC_AvatarDescriptor.Viseme.DD,  "え"  },
                { VRC_AvatarDescriptor.Viseme.kk,  "い"  },
                { VRC_AvatarDescriptor.Viseme.CH,  "い"  },
                { VRC_AvatarDescriptor.Viseme.SS,  "い"  },
                { VRC_AvatarDescriptor.Viseme.nn,  "あ"  },
                { VRC_AvatarDescriptor.Viseme.RR,  "あ"  },
                { VRC_AvatarDescriptor.Viseme.aa,  "あ"  },
                { VRC_AvatarDescriptor.Viseme.E,   "え"   },
                { VRC_AvatarDescriptor.Viseme.ih,  "あ"  },
                { VRC_AvatarDescriptor.Viseme.oh,  "お"  },
                { VRC_AvatarDescriptor.Viseme.ou,  "う"  }
            };
        }
    }
}
