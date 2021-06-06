<template>
  <div class="modal  fade show" style="display:block;background-color: #0c0c0cc9;">
    <div class="modal-dialog modal-lg">
      <div class="modal-content">
        <div class="modal-header">
          <slot name="header"><h5 class="modal-title">Modal title</h5></slot>
          <button
            type="button"
            @click="close"
            class="close"
            data-bs-dismiss="modal"
            aria-label="Close"
          ><span aria-hidden="true">×</span></button>
        </div>
        <div class="modal-body">
          <slot name="body"> 
            <p>Modal body text goes here.</p>
            </slot>
        </div>
        <div class="modal-footer">
          <slot name="footer"></slot>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "Modal",
  methods: {
    close() {
      this.$emit("close");
    },
  },
};
</script>
