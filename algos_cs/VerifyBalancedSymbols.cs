using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

public class BalancedSymbols
{
	public bool Verify(string str) {

		if(string.IsNullOrWhiteSpace(str)) {
			return true;
		}

		bool commentOpened = false;
		var stack = new Stack<char>();

		for(int i = 0; i< str.Length; i++) {
			char c = str[i];

			if(!commentOpened && isOpeningComment(str, i)) {
				commentOpened = true;
				i++;
				continue;
			}

			if(isClosingComment(str, i)) {
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
				if(hasAnotherOpenedSymbol(c, top)) {
					return false;
				}
			} 
		}
		
		return stack.Count == 0 && commentOpened == false;
	}

	private bool isOpeningComment(string str, int idx) {
		var c = str[idx];
		return c == '/' && idx < str.Length - 1 && str[idx+1] == '*';
	}

	private bool isClosingComment(string str, int idx) {
		var c = str[idx];
		return c == '*' && idx < str.Length - 1 && str[idx+1] == '/';
	}

	private bool isOpeningSymbol(char c) {
		return c == '(' || c == '{' || c == '[';
	} 

	private bool isClosingSymbol(char c) {
		return c == ')' || c == '}' || c == ']';
	} 

	private bool hasAnotherOpenedSymbol(char c, char top) {
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
