// Kurt Kaiser
// Singly-linked lists are already defined with this interface:
// class ListNode<T> {
//   public T value { get; set; }
//   public ListNode<T> next { get; set; }
// }
//
ListNode<int> mergeTwoLinkedLists(ListNode<int> l1, ListNode<int> l2) {
    if(l1 == null) return l2;
    if(l2 == null) return l1;
    ListNode<int> combo = new ListNode<int>();
    ListNode<int> head = combo;
    ListNode<int> prev = null;
    combo.value = l1.value;
    combo.next = null;
    l1 = l1.next;
    while(l1 != null || l2 != null){
        if(LessThanCombo(l2)) l2 = l2.next;       
        if(MoreThanCombo(l2, l1)) l2 = l2.next;
        if(LessThanCombo(l1)) l1 = l1.next;
        if(MoreThanCombo(l1, l2)) l1 = l1.next;
    }
    
    bool LessThanCombo(ListNode<int> node){
        if (node != null && node.value <= combo.value){
            ListNode<int> temp = new ListNode<int>();   
            temp.value = node.value;
            temp.next = combo;
            if(prev != null) {
                prev.next = temp;
            } else {
                head = temp;
            }
            prev = temp;
            return true;
        } 
        return false;
    }
    
    bool MoreThanCombo(ListNode<int> node, ListNode<int> node2){
        if (node != null && (node2 == null || combo.value < node.value && node.value <= node2.value)){
            ListNode<int> temp = new ListNode<int>();             
            temp.value = node.value;
            temp.next = null;
            combo.next = temp;
            prev = combo;
            combo = combo.next;
            return true;
        } 
        return false;
    }
    return head;
}
// Interview prep from CodeSignal.com
