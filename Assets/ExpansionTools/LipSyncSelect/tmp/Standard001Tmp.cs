using System.Collections.Generic;
using VRCSDK2;

namespace ExpansionTools.LipSyncSelect.tmp
{
    public class Standard001Tmp : ITmpInterface
    {
        public Dictionary<VRC_AvatarDescriptor.Viseme, string> GetDataSet()
        {
            return new Dictionary<VRC_AvatarDescriptor.Viseme, string>
            {
                { VRC_AvatarDescriptor.Viseme.sil, "vrc.v_sil" },
                { VRC_AvatarDescriptor.Viseme.PP,  "vrc.v_pp"  },
                { VRC_AvatarDescriptor.Viseme.FF,  "vrc.v_ff"  },
                { VRC_AvatarDescriptor.Viseme.TH,  "vrc.v_th"  },
                { VRC_AvatarDescriptor.Viseme.DD,  "vrc.v_dd"  },
                { VRC_AvatarDescriptor.Viseme.kk,  "vrc.v_kk"  },
                { VRC_AvatarDescriptor.Viseme.CH,  "vrc.v_ch"  },
                { VRC_AvatarDescriptor.Viseme.SS,  "vrc.v_ss"  },
                { VRC_AvatarDescriptor.Viseme.nn,  "vrc.v_nn"  },
                { VRC_AvatarDescriptor.Viseme.RR,  "vrc.v_rr"  },
                { VRC_AvatarDescriptor.Viseme.aa,  "vrc.v_aa"  },
                { VRC_AvatarDescriptor.Viseme.E,   "vrc.v_ee"   },
                { VRC_AvatarDescriptor.Viseme.ih,  "vrc.v_ih"  },
                { VRC_AvatarDescriptor.Viseme.oh,  "vrc.v_oh"  },
                { VRC_AvatarDescriptor.Viseme.ou,  "vrc.v_ou"  }
            };
        }
    }
}
