﻿using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.Logic.Filters
{
    public class ChatFilterBL : BaseFilterBL
    {
        public Maybe<Guid> UserId { get; set; }
    }
}
