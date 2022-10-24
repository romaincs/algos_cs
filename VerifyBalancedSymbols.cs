using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

public class Algorithm {
	public static bool VerifyBalancedSymbols(string str) {

		if(string.IsNullOrWhiteSpace(str)) {
			return true;
		}

		bool commentOpened = false;
		var stack = new Stack<char>();

		for(int i = 0; i< str.Length; i++) {
			char c = str[i];

			if(!commentOpened && IsOpeningComment(str, i)) {
				commentOpened = true;
				i++;
				continue;
			}

			if(IsClosingComment(str, i)) {
				commentOpened = false;
				i++;
				continue;
			}

			if(commentOpened) {
				continue;
			}

			if(isOpeningSymbol(c)) {
				stack.Push(c);
			}
			else if(isClosingSymbol(c)) {
				if(stack.Count == 0 ) return false;
				
				char top = stack.Pop();
				if(HasAnotherOpenedSymbol(c, top)) {
					return false;
				}
			} 
		}
		
		return stack.Count == 0 && commentOpened == false;
	}

	public static bool IsOpeningComment(string str, int idx) {
		var c = str[idx];
		return c == '/' && idx < str.Length - 1 && str[idx+1] == '*';
	}

	public static bool IsClosingComment(string str, int idx) {
		var c = str[idx];
		return c == '*' && idx < str.Length - 1 && str[idx+1] == '/';
	}

	public static bool isOpeningSymbol(char c) {
		return c == '(' || c == '{' || c == '[';
	} 

	public static bool isClosingSymbol(char c) {
		return c == ')' || c == '}' || c == ']';
	} 

	public static bool HasAnotherOpenedSymbol(char c, char top) {
		if(c == ')' && (top == '{' || top == '[')) {
			return true;
		}
		else if(c == '}' && (top == '(' || top == '[')) {
			return true;
		}
		else if(c == ']' && (top == '(' || top == '{')) {
			return true;
		}
		else {
			return false;
		}
	}
}
