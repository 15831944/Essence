﻿/// Apache Commons Math 3.6.1
/*
 * Licensed to the Apache Software Foundation (ASF) under one or more
 * contributor license agreements.  See the NOTICE file distributed with
 * this work for additional information regarding copyright ownership.
 * The ASF licenses this file to You under the Apache License, Version 2.0
 * (the "License"); you may not use this file except in compliance with
 * the License.  You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */
namespace org.apache.commons.math3.exception
{

    using Localizable = org.apache.commons.math3.exception.util.Localizable;
    using LocalizedFormats = org.apache.commons.math3.exception.util.LocalizedFormats;

    /// <summary>
    /// Exception to be thrown when there is insufficient data to perform a computation.
    /// 
    /// @since 3.3
    /// </summary>
    public class InsufficientDataException : MathIllegalArgumentException
    {

        /// <summary>
        /// Serializable version Id. </summary>
        private const long serialVersionUID = -2629324471511903359L;

        /// <summary>
        /// Construct the exception.
        /// </summary>
        public InsufficientDataException() : this(LocalizedFormats.INSUFFICIENT_DATA)
        {
        }

        /// <summary>
        /// Construct the exception with a specific context.
        /// </summary>
        /// <param name="pattern"> Message pattern providing the specific context of the error. </param>
        /// <param name="arguments"> Values for replacing the placeholders in {@code pattern}. </param>
        public InsufficientDataException(Localizable pattern, params object[] arguments) : base(pattern, arguments)
        {
        }

        public InsufficientDataException(LocalizedFormats pattern, params object[] arguments) : base(pattern, arguments)
        {
        }
    }

}