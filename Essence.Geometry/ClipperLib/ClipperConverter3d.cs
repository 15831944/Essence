﻿// Copyright 2017 Jose Luis Rovira Martin
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using Essence.Geometry.Core.Double;
using Essence.Util.Math.Int;

namespace ClipperLib
{
    public class ClipperConverter3d : IClipperConverter3d
    {
        public ClipperConverter3d(Point3d origin, int digits)
        {
            this.digits = digits;
            this.e = MathUtils.Pow(10, this.digits);
            this.origin = origin;
        }

        protected readonly int digits;
        protected readonly int e;
        protected readonly Point3d origin;

        #region IClipperConverter3d

        public virtual void Clear()
        {
        }

        public virtual IntPoint ToIntPoint(Point3d p)
        {
            return new IntPoint((long)(this.e * (p.X - this.origin.X)),
                                (long)(this.e * (p.Y - this.origin.Y)),
                                (long)(this.e * (p.Z - this.origin.Z)));
        }

        public virtual Point3d FromIntPoint(IntPoint ip)
        {
            return new Point3d((ip.X / (double)this.e) + this.origin.X,
                               (ip.Y / (double)this.e) + this.origin.Y,
                               (ip.Z / (double)this.e) + this.origin.Z);
        }

        public virtual void ZFill(Point3d bot1, Point3d top1,
                                  Point3d bot3, Point3d top3,
                                  ref Point3d pt)
        {
        }

        #endregion

        #region IClipperConverter

        public virtual void ZFill(IntPoint bot1, IntPoint top1,
                                  IntPoint bot2, IntPoint top2,
                                  ref IntPoint pt)
        {
            Point3d _pt = this.FromIntPoint(pt);
            this.ZFill(this.FromIntPoint(bot1), this.FromIntPoint(top1),
                       this.FromIntPoint(bot2), this.FromIntPoint(top2),
                       ref _pt);
            pt = this.ToIntPoint(_pt);
        }

        public virtual bool UseZFill
        {
            get { return false; }
        }

        #endregion
    }
}