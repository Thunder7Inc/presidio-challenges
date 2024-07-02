def lengthOfLongestSubstring(self, s: str) -> int:
        left = max_length = 0
        char_set = set()

        for right in range(len(s)):
            while s[right] in char_set:
                char_set.remove(s[left])
                left += 1

            char_set.add(s[right])
            max_length = max(max_length, right - left + 1)

        return max_length

# 6. Zigzag Conversion
def convert(self, s: str, numRows: int) -> str:
    if numRows == 1 or numRows >= len(s):
        return s

    rows = [[] for row in range(numRows)]
    index = 0
    step = -1
    for char in s:
        rows[index].append(char)
        if index == 0:
            step = 1
        elif index == numRows - 1:
            step = -1
        index += step

    for i in range(numRows):
        rows[i] = ''.join(rows[i])
    return ''.join(rows)

# 16. 3Sum Closest
def threeSumClosest(self, nums: list[int], target: int) -> int:
    nums.sort()
    res = sum(nums[:3])
    for i in range(len(nums) - 2):
        start = i + 1
        end = len(nums) - 1

        while start < end:
            current_sum = nums[i]+nums[start]+nums[end]
            if current_sum > target:
                end -= 1
            else:
                start += 1
            if abs(current_sum - target) < abs(res - target):
                res = current_sum
    return res

# 22. Generate Parentheses
def generateParenthesis(self, n: int) -> List[str]:
    n -= 1
    result = {"()"}

    while n > 0:
        newResult = set()
        for item in result:
            for i in range(len(item)):
                newResult.add(item[:i] + "()" + item[i:])
        result = newResult
        n -= 1
    return result

# 43. Multiply Strings
def multiply(self, num1: str, num2: str) -> str:
    return str(int(num1) * int(num2))

# 49. Group Anagrams
def groupAnagrams(self, strs: list[str]) -> list[list[str]]:
    grouped = {}
    for word in strs:
        sorted_word = ''.join(sorted(word))
        if sorted_word in grouped:
            grouped[sorted_word].append(word)
        else:
            grouped[sorted_word] = [word]
    return list(grouped.values())

# 55. Jump Game
def canJump(self, nums: list[int]) -> bool:
    last_position = 0
    for i in range(len(nums)):
        if i > last_position:
            return False
        last_position = max(last_position, i + nums[i])
        if last_position >= len(nums) - 1:
            return True
    return last_position >= len(nums) - 1

# 62. Unique Paths
def uniquePaths(self, m: int, n: int) -> int:
    oldrow = [1]*n
    for i in range(m-1):
        newrow = [1]*n
        for j in range(n-2, -1, -1):
            newrow[j] = newrow[j+1] + oldrow[j]
        oldrow = newrow
    return oldrow[0]
