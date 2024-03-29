﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Engine
{
    public class Sound
    {
        public int Channel { get; set; }

        public bool FailedToPlay
        {
            get
            {
                // minus is an error state.
                return (Channel == -1);
            }
        }

        public Sound(int channel)
        {
            Channel = channel;
        }
    }
}
