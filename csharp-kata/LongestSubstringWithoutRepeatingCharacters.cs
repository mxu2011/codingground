using System;
using System.Linq;
using System.Text;

public class LongestSubstringWithoutRepeatingCharacters
{
    public int FindLongestSubstringLength(string str)
    {
        var currentLen =1; // lenght of current substring
        var maxLen = 1; // result
        
        /* Initialize the visited array as -1, -1 is used to
            indicate that character has not been visited yet. */
        var lastVisitedIndex = Enumerable.Repeat(-1,256).ToArray();
        
        /* Mark first character as visited by storing the index
            of first   character in visited array. */
        lastVisitedIndex[str[0]] = 0;

        /* Start from the second character. First character is
            already processed (cur_len and max_len are initialized
            as 1, and visited[str[0]] is set */
        for(int i=1;i<str.Length;i++)
        {
            //  previous index
            var prevIndex = lastVisitedIndex[str[i]];
            
            /* If the currentt character is not present in the
           already processed substring or it is not part of
           the current NRCS, then do cur_len++ */
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
                if(currentLen > maxLen)
                    maxLen = currentLen;
                    
                currentLen=i-prevIndex;
            }
             // update the index of current character
            lastVisitedIndex[str[i]] = i;
        }
        
        // Compare the length of last NRCS with max_len and
        // update max_len if needed
        if(currentLen > maxLen)
            maxLen = currentLen;
            
        return maxLen;
    }
}