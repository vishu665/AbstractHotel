﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web.Models
{
    public class ReportModel
    {
        public DateTime From { get; set; }

        public DateTime To { get; set; }

        public bool SendMail { get; set; }
    }
}
