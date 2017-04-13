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

using System;

namespace Essence.Geometry.Core.Double
{
    /// <summary>
    ///     Trasnsformacion 2D a partir de una matriz.
    /// </summary>
    public sealed class Transform3DMatrix : Transform3D
    {
        public Transform3DMatrix(Matrix4x4d matrix, bool share = true)
        {
            this.matrix = (share ? matrix : matrix.Clone());
        }

        public Transform3DMatrix(double m00, double m01, double m02, double m03,
                                 double m10, double m11, double m12, double m13,
                                 double m20, double m21, double m22, double m23,
                                 double m30, double m31, double m32, double m33)
        {
            this.matrix = new Matrix4x4d(m00, m01, m02, m03,
                                         m10, m11, m12, m13,
                                         m20, m21, m22, m23,
                                         m30, m31, m32, m33);
        }

        public override IVector3D Transform(IVector3D v)
        {
            return this.matrix.Mul(v.ToVector3d());
        }

        public override IPoint3D Transform(IPoint3D p)
        {
            return this.matrix.Mul(p.ToPoint3d());
        }

        public override ITransform3D Concat(ITransform3D transform)
        {
            if (transform is Transform3DIdentity)
            {
                return transform;
            }

            Transform3DMatrix tmatrix = transform as Transform3DMatrix;
            if (tmatrix == null)
            {
                throw new NotImplementedException();
            }

            Matrix4x4d result = this.matrix.Clone();
            result.Mul(tmatrix.matrix);
            return new Transform3DMatrix(result, true);
        }

        public override ITransform3D Inv
        {
            get
            {
                if (this.inv == null)
                {
                    Matrix4x4d aux = this.matrix.Clone();
                    aux.Inv();
                    this.inv = new Transform3DMatrix(aux);
                    this.inv.inv = this;
                }
                return this.inv;
            }
        }

        public override bool IsIdentity
        {
            get { return this.matrix.IsIdentity; }
        }

        public Matrix4x4d Matrix
        {
            get { return this.matrix; }
        }

        #region private

        private readonly Matrix4x4d matrix;
        private Transform3DMatrix inv;

        #endregion
    }
}