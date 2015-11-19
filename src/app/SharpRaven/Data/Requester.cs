﻿#region License

// Copyright (c) 2014 The Sentry Team and individual contributors.
// All rights reserved.
// 
// Redistribution and use in source and binary forms, with or without modification, are permitted
// provided that the following conditions are met:
// 
//     1. Redistributions of source code must retain the above copyright notice, this list of
//        conditions and the following disclaimer.
// 
//     2. Redistributions in binary form must reproduce the above copyright notice, this list of
//        conditions and the following disclaimer in the documentation and/or other materials
//        provided with the distribution.
// 
//     3. Neither the name of the Sentry nor the names of its contributors may be used to
//        endorse or promote products derived from this software without specific prior written
//        permission.
// 
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR
// IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR
// CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL
// DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE,
// DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY,
// WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN
// ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.

#endregion

namespace SharpRaven.Data
{
    /// <summary>
    /// The class responsible for performing the HTTP request to Sentry.
    /// </summary>
    public partial class Requester
    {
        private readonly RequestData data;
        private readonly RavenClient ravenClient;


        /// <summary>
        /// Initializes a new instance of <see cref="Requester"/>.
        /// </summary>
        /// <param name="ravenClient">The <see cref="RavenClient"/></param>
        /// <param name="packet">The <see cref="JsonPacket"/> to </param>
        private Requester(RavenClient ravenClient, JsonPacket packet)
            : this(ravenClient)
        {
            this.data = new RequestData(this, packet);
        }


        /// <summary>
        /// Gets the <see cref="IRavenClient"/>.
        /// </summary> 
        public IRavenClient Client
        {
            get { return this.ravenClient; }
        }

        /// <summary>
        /// 
        /// </summary>
        public RequestData Data
        {
            get { return this.data; }
        }


        /// <summary>
        /// Prepares the <see cref="Requester"/> with the <paramref name="packet"/>.
        /// </summary>
        /// <param name="packet">The <see cref="JsonPacket"/> to prepare for the upcoming request.</param>
        /// <returns>The prepared <see cref="Requester"/>.</returns>
        public Requester Prepare(JsonPacket packet)
        {
            return new Requester(this.ravenClient, packet);
        }
    }
}