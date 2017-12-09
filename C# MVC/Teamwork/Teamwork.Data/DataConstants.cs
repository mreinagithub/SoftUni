﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Teamwork.Data
{
    public static class DataConstants
    {
        public const int UserNameMinLength = 2;
        public const int UserNameMaxLength = 100;

        public const int ProjectNameMinLength = 2;
        public const int ProjectNameMaxLength = 100;

        public const int AssessmentCommentMinLength = 10;
        public const int AssessmentGradeMinValue = 0;
        public const int AssessmentGradeMaxValue = 5;
    }
}