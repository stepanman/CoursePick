﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubjectPickDataAccess
{
    interface IDbInteractor : IStudentInteractor, ISubjectInteractor, ITutorInteractor {}
}