﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cyberpalata.Common.Enums;
using Cyberpalata.Logic.Models.Devices;
using Cyberpalata.Logic.Models.Peripheral;

namespace Cyberpalata.Logic.Models.Rooms
{
    public class GamingRoomDto : RoomDto
    {

        public List<DeviceDto> Devices { get; set; } = new();

        public List<PeripheryDto> Peripheries { get; set; } = new();

        public GamingRoomType Type { get; set; } = GamingRoomType.Common;
    }
}
