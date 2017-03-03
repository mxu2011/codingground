using System;
using System.Linq;
using System.Text;

public class LongestSubstringWithoutRepeatingCharacters
{
    public int FindLongestSubstringLength(string str)
    {
        if (str == null || str.Length == 0) {
            return 0;
        }
        
        var currentLen = 1; 
        var maxLen = 1; 
        
        /* Initialize the visited array as -1, -1 is used to
            indicate that character has not been visited yet. */
        var lastVisitedIndex = Enumerable.Repeat(-1,256).ToArray();
        
        lastVisitedIndex[str[0]] = 0;

        for(int i = 1;i < str.Length; i++)
        {
            //  previous index
            var prevIndex = lastVisitedIndex[str[i]];
            
            /* If the currentt character is not present in the
           already processed substring or it is not part of
           the current non repeating current substring (NRCS), 
           then currentLen++ */
           
            if(prevIndex == -1 || i - currentLen > prevIndex)
            {
                currentLen++;
            }
            /* If the current character is present in currently
           considered NRCS, then update NRCS to start from
           the next character of previous instance. */
            else
            {
                /* Also, when we are changing the NRCS, we
               should also check whether length of the
               previous NRCS was greater than max_len or
               not.*/
                if(currentLen > maxLen) {
                    maxLen = currentLen;
                }
                    
                currentLen = i - prevIndex;
            }
             // update the index of current character
            lastVisitedIndex[str[i]] = i;
        }
        
        // Compare the length of last NRCS with max_len and
        // update max_len if needed
        if (currentLen > maxLen) {
           maxLen = currentLen; 
        }
            
        return maxLen;
    }
}