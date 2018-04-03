/*
 * BATester.Standard
 *
 * This file was automatically generated by APIMATIC v2.0 ( https://apimatic.io )
 */
using System;
using System.Linq;
using System.Collections.Generic;
using BATester.Standard;
using BATester.Standard.Utilities;

namespace BATester.Standard.Models
{
    public enum SuiteCodeEnum
    {
        HEARTS = 1, //TODO: Write general description for this method
        SPADES = 2, //TODO: Write general description for this method
        CLUBS = 3, //TODO: Write general description for this method
        DIAMONDS = 4, //TODO: Write general description for this method
    }

    /// <summary>
    /// Helper for the enum type SuiteCodeEnum
    /// </summary>
    public static class SuiteCodeEnumHelper
    {
        /// <summary>
        /// Convert a list of SuiteCodeEnum values to a list of integers
        /// </summary>
        /// <param name="enumValues">The list of SuiteCodeEnum values to convert</param>
        /// <returns>The list of representative integer values</returns>
        public static List<int> ToValue(List<SuiteCodeEnum> enumValues)
        {
            if (null == enumValues)
                return null;
            
            return enumValues.Select(eVal => (int)eVal).ToList();
        }
    }
} 