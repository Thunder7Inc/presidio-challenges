def longest_substring_without_repeating_characters(s):
    n = len(s)
    if n <= 1:
        return s

    char_index = {}
    max_len = 0
    start = 0
    longest_substr = ""

    for end in range(n):
        if s[end] in char_index and char_index[s[end]] >= start:
            start = char_index[s[end]] + 1
        char_index[s[end]] = end

        if end - start + 1 > max_len:
            max_len = end - start + 1
            longest_substr = s[start:end + 1]

    return longest_substr

# sample test cases
string = "abcabcbb"
print(longest_substring_without_repeating_characters(string))  # abc

string = "bbbbb"
print(longest_substring_without_repeating_characters(string))  # b

string = "pwwkew"
print(longest_substring_without_repeating_characters(string))  # wke

string = "dvdf"
print(longest_substring_without_repeating_characters(string))  # vdf
