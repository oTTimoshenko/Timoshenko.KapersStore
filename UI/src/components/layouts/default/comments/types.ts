class KaperComment {
  id!: number;
  parentId!: number;
  userNickname!: string;
  date!: string;
  text!: string;

  get isParent(): boolean {
    return this.parentId === 0;
  }

  constructor(id: number, parentId: number, userNickname: string, date: string, text: string) {
    this.id = id;
    this.parentId = parentId;
    this.userNickname = userNickname;
    this.date = date;
    this.text = text;
  }
}

class KaperCommentsGroup {
  parent!: KaperComment;
  children!: KaperComment[]; 

  constructor(parent: KaperComment, children: KaperComment[]) {
    this.parent = parent;
    this.children = children || [];
  }
}

class KaperCommentsTree {
  private comments!: KaperComment[];

  get commentsGroups(): KaperCommentsGroup[] {
    const parentComments = this.comments.filter(comment => comment.isParent);

    return parentComments.map(parent => 
            new KaperCommentsGroup(parent, this.comments
              .filter(comment => comment.parentId === parent.id)));
  }

  get commentsCount() {
    return this.comments.length;
  }

  constructor(comments?: KaperComment[]) {
    this.comments = comments || [];
  }

  addComment(comment: KaperComment) {
    this.comments.push(comment);
  }

  removeComment(id: number) {
    this.comments = this.comments.filter(comment => comment.id !== id && comment.parentId !== id);
  }

  nextId(): number {
    const ids = this.comments.map(c => c.id).sort();
    return ids[ids.length - 1] + 1;
  }
}

export { KaperComment, KaperCommentsGroup, KaperCommentsTree }