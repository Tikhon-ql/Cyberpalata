﻿using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.Logic.Filters
{
    public class TeamJoinRequestFilterBL : BaseFilterBL
    {
        public Maybe<Guid> TeamId { get; set; }
    }
}