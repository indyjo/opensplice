/*
 *                         Vortex OpenSplice
 *
 *   This software and documentation are Copyright 2006 to TO_YEAR ADLINK
 *   Technology Limited, its affiliated companies and licensors. All rights
 *   reserved.
 *
 *   Licensed under the Apache License, Version 2.0 (the "License");
 *   you may not use this file except in compliance with the License.
 *   You may obtain a copy of the License at
 *
 *       http://www.apache.org/licenses/LICENSE-2.0
 *
 *   Unless required by applicable law or agreed to in writing, software
 *   distributed under the License is distributed on an "AS IS" BASIS,
 *   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 *   See the License for the specific language governing permissions and
 *   limitations under the License.
 */

//using System;
//using System.Runtime.InteropServices;
//using DDS.OpenSplice;
//
//namespace DDS.OpenSplice.CustomMarshalers
//{
//
//    internal static class MarshalHelper
//    {
//        public static IntPtr GetIntPtrForDelegate(Delegate d)
//        {
//            return d == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(d);
//        }
//    }
//
//    internal class TopicListenerMarshaler : GapiMarshaler
//    {
//        private static Type topicListenerType = typeof(OpenSplice.Gapi.gapi_topicListener);
//        public static readonly int Size = Marshal.SizeOf(topicListenerType);
//
//        private static int offset_listener_data = (int)Marshal.OffsetOf(topicListenerType, "listener_data");
//        private static int offset_on_inconsistent_topic = (int)Marshal.OffsetOf(topicListenerType, "on_inconsistent_topic");
//
//        public TopicListenerMarshaler(ref OpenSplice.Gapi.gapi_topicListener listener)
//            : this()
//        {
//            CopyIn(ref listener, GapiPtr, 0);
//            cleanupRequired = true;
//        }
//
//        public TopicListenerMarshaler() :
//                base(Gapi.GenericAllocRelease.Alloc(Size))
//        { }
//
//        public override void Dispose()
//        {
//            if (cleanupRequired)
//            {
//                CleanupIn(GapiPtr, 0);
//            }
//
//            OpenSplice.Gapi.GenericAllocRelease.Free(GapiPtr);
//        }
//
//        internal static void CopyIn(ref OpenSplice.Gapi.gapi_topicListener from, IntPtr to, int offset)
//        {
//            // Set listener_data field
//            //            Marshal.WriteIntPtr(to, offset + offset_listener_data, from.listener_data);
//            BaseMarshaler.Write(to, offset + offset_listener_data, IntPtr.Zero);
//
//            // Set on_inconsistent_topic field
//            BaseMarshaler.Write(to, offset + offset_on_inconsistent_topic, MarshalHelper.GetIntPtrForDelegate(from.on_inconsistent_topic));
//        }
//
//        internal static void CleanupIn(IntPtr pNativeData, int offset)
//        {
//            // Currently nothing to cleanup.
//        }
//    }
//
//    internal class PublisherDataWriterListenerMarshaler : GapiMarshaler
//    {
//        private static Type type = typeof(OpenSplice.Gapi.gapi_publisherDataWriterListener);
//        public static readonly int Size = Marshal.SizeOf(type);
//
//        private static int offset_listener_data = (int)Marshal.OffsetOf(type, "listener_data");
//        private static int offset_on_offered_deadline_missed = (int)Marshal.OffsetOf(type, "on_offered_deadline_missed");
//        private static int offset_on_offered_incompatible_qos = (int)Marshal.OffsetOf(type, "on_offered_incompatible_qos");
//        private static int offset_on_liveliness_lost = (int)Marshal.OffsetOf(type, "on_liveliness_lost");
//        private static int offset_on_publication_match = (int)Marshal.OffsetOf(type, "on_publication_match");
//
//        public PublisherDataWriterListenerMarshaler(ref OpenSplice.Gapi.gapi_publisherDataWriterListener listener)
//            : this()
//        {
//            CopyIn(ref listener, GapiPtr, 0);
//            cleanupRequired = true;
//        }
//
//        public PublisherDataWriterListenerMarshaler() :
//                base(Gapi.GenericAllocRelease.Alloc(Size))
//        { }
//
//        public override void Dispose()
//        {
//            if (cleanupRequired)
//            {
//                CleanupIn(GapiPtr, 0);
//            }
//
//            OpenSplice.Gapi.GenericAllocRelease.Free(GapiPtr);
//        }
//
//        internal static void CopyIn(ref OpenSplice.Gapi.gapi_publisherDataWriterListener from, IntPtr to, int offset)
//        {
//            // Set listener_data field
//            //            Marshal.WriteIntPtr(to, offset + offset_listener_data, from.listener_data);
//            BaseMarshaler.Write(to, offset + offset_listener_data, IntPtr.Zero);
//
//            // Set callback fields
//            BaseMarshaler.Write(to, offset + offset_on_offered_deadline_missed, MarshalHelper.GetIntPtrForDelegate(from.on_offered_deadline_missed));
//            BaseMarshaler.Write(to, offset + offset_on_offered_incompatible_qos, MarshalHelper.GetIntPtrForDelegate(from.on_offered_incompatible_qos));
//            BaseMarshaler.Write(to, offset + offset_on_liveliness_lost, MarshalHelper.GetIntPtrForDelegate(from.on_liveliness_lost));
//            BaseMarshaler.Write(to, offset + offset_on_publication_match, MarshalHelper.GetIntPtrForDelegate(from.on_publication_match));
//        }
//
//        internal static void CleanupIn(IntPtr pNativeData, int offset)
//        {
//            // Currently nothing to cleanup.
//        }
//
//    }
//
//    internal class DataReaderListenerMarshaler : GapiMarshaler
//    {
//        private static Type type = typeof(OpenSplice.Gapi.gapi_dataReaderListener);
//        public static readonly int Size = Marshal.SizeOf(type);
//
//        private static int offset_listener_data = (int)Marshal.OffsetOf(type, "listener_data");
//        private static int offset_on_requested_deadline_missed = (int)Marshal.OffsetOf(type, "on_requested_deadline_missed");
//        private static int offset_on_requested_incompatible_qos = (int)Marshal.OffsetOf(type, "on_requested_incompatible_qos");
//        private static int offset_on_sample_rejected = (int)Marshal.OffsetOf(type, "on_sample_rejected");
//        private static int offset_on_liveliness_changed = (int)Marshal.OffsetOf(type, "on_liveliness_changed");
//        private static int offset_on_data_available = (int)Marshal.OffsetOf(type, "on_data_available");
//        private static int offset_on_subscription_match = (int)Marshal.OffsetOf(type, "on_subscription_match");
//        private static int offset_on_sample_lost = (int)Marshal.OffsetOf(type, "on_sample_lost");
//
//        public DataReaderListenerMarshaler(ref OpenSplice.Gapi.gapi_dataReaderListener listener)
//            : this()
//        {
//            CopyIn(ref listener, GapiPtr, 0);
//            cleanupRequired = true;
//        }
//
//        public DataReaderListenerMarshaler() :
//                base(Gapi.GenericAllocRelease.Alloc(Size))
//        { }
//
//        public override void Dispose()
//        {
//            if (cleanupRequired)
//            {
//                CleanupIn(GapiPtr, 0);
//            }
//
//            OpenSplice.Gapi.GenericAllocRelease.Free(GapiPtr);
//        }
//
//        internal static void CopyIn(ref OpenSplice.Gapi.gapi_dataReaderListener from, IntPtr to, int offset)
//        {
//            // Set listener_data field
//            //            Marshal.WriteIntPtr(to, offset + offset_listener_data, from.listener_data);
//            BaseMarshaler.Write(to, offset + offset_listener_data, IntPtr.Zero);
//
//            // Set callback fields
//            BaseMarshaler.Write(to, offset + offset_on_requested_deadline_missed, MarshalHelper.GetIntPtrForDelegate(from.on_requested_deadline_missed));
//            BaseMarshaler.Write(to, offset + offset_on_requested_incompatible_qos, MarshalHelper.GetIntPtrForDelegate(from.on_requested_incompatible_qos));
//            BaseMarshaler.Write(to, offset + offset_on_sample_rejected, MarshalHelper.GetIntPtrForDelegate(from.on_sample_rejected));
//            BaseMarshaler.Write(to, offset + offset_on_liveliness_changed, MarshalHelper.GetIntPtrForDelegate(from.on_liveliness_changed));
//            BaseMarshaler.Write(to, offset + offset_on_data_available, MarshalHelper.GetIntPtrForDelegate(from.on_data_available));
//            BaseMarshaler.Write(to, offset + offset_on_subscription_match, MarshalHelper.GetIntPtrForDelegate(from.on_subscription_match));
//            BaseMarshaler.Write(to, offset + offset_on_sample_lost, MarshalHelper.GetIntPtrForDelegate(from.on_sample_lost));
//        }
//
//        internal static void CleanupIn(IntPtr pNativeData, int offset)
//        {
//            // Currently nothing to cleanup.
//        }
//
//    }
//
//    internal class SubscriberListenerMarshaler : GapiMarshaler
//    {
//        private static Type type = typeof(OpenSplice.Gapi.gapi_subscriberListener);
//        public static readonly int Size = Marshal.SizeOf(type);
//
//        private static int offset_dataReader = (int)Marshal.OffsetOf(type, "dataReader");
//        private static int offset_on_data_on_readers = (int)Marshal.OffsetOf(type, "on_data_on_readers");
//
//        public SubscriberListenerMarshaler(ref OpenSplice.Gapi.gapi_subscriberListener listener)
//            : this()
//        {
//            CopyIn(ref listener, GapiPtr, 0);
//            cleanupRequired = true;
//        }
//
//        public SubscriberListenerMarshaler() :
//                base(Gapi.GenericAllocRelease.Alloc(Size))
//        { }
//
//        public override void Dispose()
//        {
//            if (cleanupRequired)
//            {
//                CleanupIn(GapiPtr, 0);
//            }
//
//            OpenSplice.Gapi.GenericAllocRelease.Free(GapiPtr);
//        }
//
//        internal static void CopyIn(ref OpenSplice.Gapi.gapi_subscriberListener from, IntPtr to, int offset)
//        {
//            DataReaderListenerMarshaler.CopyIn(ref from.dataReader, to, offset_dataReader);
//
//            // set on_data_on_readers field
//            BaseMarshaler.Write(to, offset + offset_on_data_on_readers, MarshalHelper.GetIntPtrForDelegate(from.on_data_on_readers));
//        }
//
//        internal static void CleanupIn(IntPtr pNativeData, int offset)
//        {
//            // Currently nothing to cleanup.
//        }
//    }
//
//    internal class DomainParticipantListenerMarshaler : GapiMarshaler
//    {
//        private static Type type = typeof(OpenSplice.Gapi.gapi_domainParticipantListener);
//        public static readonly int Size = Marshal.SizeOf(type);
//
//        private static int offset_listener_data = (int)Marshal.OffsetOf(type, "listener_data");
//        private static int offset_on_inconsistent_topic = (int)Marshal.OffsetOf(type, "on_inconsistent_topic");
//        private static int offset_on_offered_deadline_missed = (int)Marshal.OffsetOf(type, "on_offered_deadline_missed");
//        private static int offset_on_offered_incompatible_qos = (int)Marshal.OffsetOf(type, "on_offered_incompatible_qos");
//        private static int offset_on_liveliness_lost = (int)Marshal.OffsetOf(type, "on_liveliness_lost");
//        private static int offset_on_publication_match = (int)Marshal.OffsetOf(type, "on_publication_match");
//        private static int offset_on_requested_deadline_missed = (int)Marshal.OffsetOf(type, "on_requested_deadline_missed");
//        private static int offset_on_requested_incompatible_qos = (int)Marshal.OffsetOf(type, "on_requested_incompatible_qos");
//        private static int offset_on_sample_rejected = (int)Marshal.OffsetOf(type, "on_sample_rejected");
//        private static int offset_on_liveliness_changed = (int)Marshal.OffsetOf(type, "on_liveliness_changed");
//        private static int offset_on_data_available = (int)Marshal.OffsetOf(type, "on_data_available");
//        private static int offset_on_subscription_match = (int)Marshal.OffsetOf(type, "on_subscription_match");
//        private static int offset_on_sample_lost = (int)Marshal.OffsetOf(type, "on_sample_lost");
//        private static int offset_on_data_on_readers = (int)Marshal.OffsetOf(type, "on_data_on_readers");
//
//        public DomainParticipantListenerMarshaler(ref OpenSplice.Gapi.gapi_domainParticipantListener listener)
//            : this()
//        {
//            CopyIn(ref listener, GapiPtr, 0);
//            cleanupRequired = true;
//        }
//
//        public DomainParticipantListenerMarshaler() :
//                base(Gapi.GenericAllocRelease.Alloc(Size))
//        { }
//
//        public override void Dispose()
//        {
//            if (cleanupRequired)
//            {
//                CleanupIn(GapiPtr, 0);
//            }
//
//            OpenSplice.Gapi.GenericAllocRelease.Free(GapiPtr);
//        }
//
//        public static void CopyIn(ref Gapi.gapi_domainParticipantListener from, IntPtr to, int offset)
//        {
//            // Set listener_data field
//            BaseMarshaler.Write(to, offset + offset_listener_data, IntPtr.Zero);
//
//            // Set callback fields
//            BaseMarshaler.Write(to, offset + offset_on_inconsistent_topic, MarshalHelper.GetIntPtrForDelegate(from.on_inconsistent_topic));
//            BaseMarshaler.Write(to, offset + offset_on_offered_deadline_missed, MarshalHelper.GetIntPtrForDelegate(from.on_offered_deadline_missed));
//            BaseMarshaler.Write(to, offset + offset_on_offered_incompatible_qos, MarshalHelper.GetIntPtrForDelegate(from.on_offered_incompatible_qos));
//            BaseMarshaler.Write(to, offset + offset_on_liveliness_lost, MarshalHelper.GetIntPtrForDelegate(from.on_liveliness_lost));
//            BaseMarshaler.Write(to, offset + offset_on_publication_match, MarshalHelper.GetIntPtrForDelegate(from.on_publication_match));
//            BaseMarshaler.Write(to, offset + offset_on_requested_deadline_missed, MarshalHelper.GetIntPtrForDelegate(from.on_requested_deadline_missed));
//            BaseMarshaler.Write(to, offset + offset_on_requested_incompatible_qos, MarshalHelper.GetIntPtrForDelegate(from.on_requested_incompatible_qos));
//            BaseMarshaler.Write(to, offset + offset_on_sample_rejected, MarshalHelper.GetIntPtrForDelegate(from.on_sample_rejected));
//            BaseMarshaler.Write(to, offset + offset_on_liveliness_changed, MarshalHelper.GetIntPtrForDelegate(from.on_liveliness_changed));
//            BaseMarshaler.Write(to, offset + offset_on_data_available, MarshalHelper.GetIntPtrForDelegate(from.on_data_available));
//            BaseMarshaler.Write(to, offset + offset_on_subscription_match, MarshalHelper.GetIntPtrForDelegate(from.on_subscription_match));
//            BaseMarshaler.Write(to, offset + offset_on_sample_lost, MarshalHelper.GetIntPtrForDelegate(from.on_sample_lost));
//            BaseMarshaler.Write(to, offset + offset_on_data_on_readers, MarshalHelper.GetIntPtrForDelegate(from.on_data_on_readers));
//        }
//
//        public static void CleanupIn(IntPtr nativeData, int offset)
//        {
//            // Currently nothing to cleanup.
//        }
//    }
//}